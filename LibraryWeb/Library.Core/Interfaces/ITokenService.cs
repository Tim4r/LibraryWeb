using Library.Data.Models;

namespace Library.Core.Interfaces;

public interface ITokenService
{
    Task<(string, string)> CreateAccessRefreshTokenAsync(User user);
    Task<string> CreateAccessTokenAsync(User user);
    Task CreateRefreshTokenAsync(User user, string refreshToken);
    protected string GenerateRefreshToken();
    void CheckAccessTokenValidation(User user, IList<string> roles);
}
