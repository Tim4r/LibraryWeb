using Library.Data.Models;

namespace Library.Core.Interfaces;

public interface ITokenService
{
    Task<string> CreateTokenAsync(User user);
}
