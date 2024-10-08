using Library.Data.Models;

namespace Library.Data.Repository;

public interface IUserRepository
{
    //Task<User> CreateUserAsync(User user);
    Task<User> GetUserWithEmail(User user);
    Task<User> Register(User user);
    //Task<User> Login(string email);
}
