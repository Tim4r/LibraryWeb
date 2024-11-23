using Library.Core.Dtos;
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
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userResult = await _userManager.FindByNameAsync(registerDto.Username);
            if (userResult != null)
                return BadRequest("A user with this login already exists. Please, change the login to a unique one!");

            var emailResult = await _userManager.FindByEmailAsync(registerDto.Email);
            if (emailResult != null)
                return BadRequest("A user with this email already exists. Please, change the email to a unique one!");

            var user = new User { UserName = registerDto.Username, Email = registerDto.Email };
            var resultUserCreation = await _userManager.CreateAsync(user, registerDto.Password);

            if (resultUserCreation.Succeeded)
            {
                var resultAddUserRole = await _userManager.AddToRoleAsync(user, "User");
                if (resultAddUserRole.Succeeded)
                {
                    return Ok(
                        new NewUserDto
                        {
                            UserName = registerDto.Username,
                            Email = registerDto.Email,
                            Token = await _tokenService.CreateTokenAsync(user)
                        }
                    );
                }
                else
                {
                    return BadRequest(resultUserCreation.Errors);
                }
            } 
            else
            {
                return BadRequest(resultUserCreation.Errors);
            }
                
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
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var user = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == loginDto.Username);
        var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);
        if (user == null || !result.Succeeded) return Unauthorized("Username and/or password incorrect");   
        
        return Ok(
            new NewUserDto
            {
                UserName = user.UserName,
                Email = user.Email,
                Token = await _tokenService.CreateTokenAsync(user)
            }
        );
    }
}
