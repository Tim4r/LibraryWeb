using Library.Data.Context;
using Library.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using ITokenService = Library.Core.Interfaces.ITokenService;

namespace Library.BL.Services;

public class TokenService : ITokenService
{
    private readonly UserManager<User> _userManager;
    private readonly IConfiguration _config;
    private readonly SymmetricSecurityKey _key;
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public TokenService(IConfiguration config, UserManager<User> userManager, IServiceScopeFactory serviceScopeFactory)
    {
        _userManager = userManager;
        _config = config;
        _serviceScopeFactory = serviceScopeFactory;

        var signingKey = _config["JWT:SigningKey"];
        if (string.IsNullOrEmpty(signingKey) || signingKey.Length < 16)
            throw new ArgumentException("JWT SigningKey must be at least 16 characters long.");

        _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:SigningKey"]));
    }

    public async Task<(string, string)> CreateAccessRefreshTokenAsync(User user)
    {
        var accessToken = await CreateAccessTokenAsync(user);
        var refreshToken = GenerateRefreshToken();
        await CreateRefreshTokenAsync(user, refreshToken);

        return (accessToken, refreshToken);
    }

    public async Task<string> CreateAccessTokenAsync(User user)
    {
        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, Convert.ToString(user.Id)),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim(JwtRegisteredClaimNames.GivenName, user.UserName)
        };

        var roles = await _userManager.GetRolesAsync(user);
        CheckAccessTokenValidation(user, roles);

        var userRole = roles.FirstOrDefault();
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
        return tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));
    }

    public async Task CreateRefreshTokenAsync(User user, string refreshToken)
    {           
        var refreshTokenEntity = new RefreshToken()
        {
            Token = refreshToken,
            UserId = user.Id,
            Expires = DateTime.UtcNow.AddDays(7),
            IsUsed = false,
            IsRevoked = false
        };

        using (var scope = _serviceScopeFactory.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDBContext>();
            dbContext.RefreshTokens.Add(refreshTokenEntity);
            await dbContext.SaveChangesAsync();
        }
    }

    public string GenerateRefreshToken()
    {
        var randomBytes = new byte[32];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(randomBytes);
        }
        return Convert.ToBase64String(randomBytes);
    }

    public void CheckAccessTokenValidation(User user, IList<string> roles)
    {
        if (roles.Count > 1)
            throw new InvalidOperationException("User can not have more, than one role!");

        var userRole = roles.FirstOrDefault() ?? throw new InvalidOperationException("User does not have an assigned role!");
    }
}
