using Library.Data.Models;

namespace Library.Core.Interfaces
{
    public interface IUserService
    {
        Task<User> Register(User user);
    }
}
