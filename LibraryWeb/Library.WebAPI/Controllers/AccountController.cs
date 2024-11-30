using Library.Core.Dtos;
using Library.Core.ViewDtos;
using Library.Data.Context;
using Library.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ITokenService = Library.Core.Interfaces.ITokenService;

namespace Library.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly UserManager<User> _userManager;
    private readonly ITokenService _tokenService;
    private readonly SignInManager<User> _signInManager;

    public AccountController(UserManager<User> userManager, ITokenService tokenService, SignInManager<User> signInManager)
    {
        _userManager = userManager;
        _tokenService = tokenService;
        _signInManager = signInManager;
    }

    [AllowAnonymous]
    [HttpPost("Register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
    {
        try
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var userResult = await _userManager.FindByNameAsync(registerDto.Username);
            if (userResult != null) return BadRequest("A user with this login already exists. Please, change the login to a unique one!");

            var emailResult = await _userManager.FindByEmailAsync(registerDto.Email);
            if (emailResult != null) return BadRequest("A user with this email already exists. Please, change the email to a unique one!");

            var user = new User { UserName = registerDto.Username, Email = registerDto.Email };

            var resultUserCreation = await _userManager.CreateAsync(user, registerDto.Password);
            if (!resultUserCreation.Succeeded) return BadRequest(resultUserCreation.Errors);

            var resultAddUserRole = await _userManager.AddToRoleAsync(user, "User");
            if (!resultAddUserRole.Succeeded) return BadRequest(resultAddUserRole.Errors);

            var (accessToken, refreshToken) = await _tokenService.CreateAccessRefreshTokenAsync(user);
            return Ok(new AuthoriseViewDto
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken
            });
        }
        catch (Exception ex) 
        {
            return StatusCode(500, $"An error occurred: {ex.Message}");
        }
    }

    [AllowAnonymous]
    [HttpPost("Login")]
    public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var user = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == loginDto.Username);
        var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);
        if (user == null || !result.Succeeded) return Unauthorized("Username and/or password incorrect");

        using (var scope = HttpContext.RequestServices.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDBContext>();
            var existingTokens = dbContext.RefreshTokens.Where(rt => rt.UserId == user.Id && !rt.IsRevoked && !rt.IsUsed).ToList();

            foreach (var token in existingTokens)
            {
                token.IsRevoked = true;
                dbContext.RefreshTokens.Update(token);
            }

            await dbContext.SaveChangesAsync();
        }

        var (accessToken, refreshToken) = await _tokenService.CreateAccessRefreshTokenAsync(user);

        return Ok(new AuthoriseViewDto
        {
            AccessToken = accessToken,
            RefreshToken = refreshToken
        });
    }

    [AllowAnonymous]
    [HttpPost("RefreshToken")]
    public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenDto refreshTokenDto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var dbContext = HttpContext.RequestServices.GetService<ApplicationDBContext>();
        var storedToken = dbContext.RefreshTokens
            .Include(rt => rt.User)
            .FirstOrDefault(rt => rt.Token == refreshTokenDto.Token);

        if (storedToken == null || storedToken.IsUsed || storedToken.IsRevoked) return Unauthorized("Invalid or expired refresh token!");

        if (storedToken.Expires < DateTime.UtcNow) return Unauthorized("Refresh token has expired");

        storedToken.IsUsed = true;
        dbContext.RefreshTokens.Update(storedToken);
        await dbContext.SaveChangesAsync();

        var user = storedToken.User;
        var (accessToken, refreshToken) = await _tokenService.CreateAccessRefreshTokenAsync(user);

        return Ok(new AuthoriseViewDto
        {
            AccessToken = accessToken,
            RefreshToken = refreshToken
        });
    }
}
