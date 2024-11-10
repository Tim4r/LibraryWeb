using Library.Core.Dtos;
using Library.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Library.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthentificationController : ControllerBase
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;

    public AuthentificationController(UserManager<User> userManager, SignInManager<User> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    [HttpPost("Register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
    {
        var userResult = await _userManager.FindByNameAsync(registerDto.Username);
        if (userResult != null) 
            return BadRequest("A user with this login already exists. Please, change the login to a unique one!");

        var user = new User { UserName = registerDto.Username, Email = registerDto.Email };
        var resultUserCreation = await _userManager.CreateAsync(user, registerDto.Password);
        if (!resultUserCreation.Succeeded)
            return BadRequest(resultUserCreation.Errors);

        var resultAddUserRole = await _userManager.AddToRoleAsync(user, "User");
        if (!resultAddUserRole.Succeeded)
            return BadRequest(resultAddUserRole.Errors);

        return Ok("User registered successfully and role assigned!");
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
    {
        var result = await _signInManager.PasswordSignInAsync(loginDto.Username, loginDto.Password, false, false);
        if (!result.Succeeded)
            return Unauthorized("Invalid username or password!");

        var user = await _userManager.FindByNameAsync(loginDto.Username);
        var roles = await _userManager.GetRolesAsync(user);
        var userRole = roles.FirstOrDefault();

        if (userRole == null)
            return Unauthorized("User does not have an assigned role!");

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(ClaimTypes.Role, userRole)
        };

        var key = Encoding.ASCII.GetBytes("YourSuperSecretKeyYourSuperSecretKey");
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddDays(1),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            Issuer = "YourIssuer",
            Audience = "YourAudience"
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);
        var tokenString = tokenHandler.WriteToken(token);

        return Ok(new { Token = tokenString });
    }
}
