using Library.Data.Context;
using Library.Data.Models;

namespace Library.Data.Repository;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDBContext _context;
    public UserRepository(ApplicationDBContext context)
    {
        _context = context;
    }
    public async Task<User> Register(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task<User> GetUserWithEmail(User user)
    {
        var userWithEmail = _context.Users.FindAsync(user.Email).Result;
        return userWithEmail;
    }

    //Task<User> Login(string email)
    //{

    //}
}
