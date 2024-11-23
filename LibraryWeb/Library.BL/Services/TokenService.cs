using Library.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ITokenService = Library.Core.Interfaces.ITokenService;

namespace Library.BL.Services;

public class TokenService : ITokenService
{
    private readonly UserManager<User> _userManager;
    private readonly IConfiguration _config;
    private readonly SymmetricSecurityKey _key;

    public TokenService(IConfiguration config, UserManager<User> userManager)
    {
        _userManager = userManager;
        _config = config;

        var signingKey = _config["JWT:SigningKey"];
        if (string.IsNullOrEmpty(signingKey) || signingKey.Length < 16)
            throw new ArgumentException("JWT SigningKey must be at least 16 characters long.");

        _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:SigningKey"]));
    }
    public async Task<string> CreateTokenAsync(User user)
    {
        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim(JwtRegisteredClaimNames.GivenName, user.UserName)
        };

        var roles = await _userManager.GetRolesAsync(user);
        if (roles.Count > 1)
            throw new InvalidOperationException("User can not have more, than one role!");

        var userRole = roles.FirstOrDefault();
        if (userRole == null)
            throw new InvalidOperationException("User does not have an assigned role!");

        claims.Add(new Claim(ClaimTypes.Role, userRole));

        var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.Now.AddMinutes(1),
            SigningCredentials = creds,
            Issuer = _config["JWT:Issuer"],
            Audience = _config["JWT:Audience"]
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }
}
