using Library.BL.Mapper;
using Library.Data.Models;
using Library.Data.Repository;
using Library.Core.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BCryptNet = BCrypt.Net.BCrypt;

namespace Library.BL.Services;

public class UserService : IUserService
{
    private readonly IConfiguration _configuration;
    private readonly IUserRepository _userRepository;

    public UserService(
        IConfiguration configuration,
        IUserRepository userRepository)
    {
        _configuration = configuration;
        _userRepository = userRepository;
    }

    //public async Task<User> Login(User userModel)
    //{
    //    var user = Authenticate(userModel).Result;

    //    user.PasswordHash = Generate(user);

    //    return user;
    //}

    public async Task<User> Register(User userModel)
    {
        try
        {
            var user = ModelToDtoMapper.Mapper.Map<User>(userModel);
            var userToFind = _userRepository.GetUserWithEmail(user);
            user.PasswordHash = BCryptNet.HashPassword(userModel.PasswordHash);
            user.PasswordSalt = BCryptNet.GenerateSalt();
            await _userRepository.Register(user);
            return userModel;

        }
        catch (Exception ex)
        {
            return null;
        }
    }

    //private async Task<User> Authenticate(User userModel)
    //{
    //    var user = MapperApp.Mapper.Map<User>(userModel);
    //    user = await _userRepository.GetUserWithEmail(user);
    //    if (user == null || !BCryptNet.Verify(userModel.Password, user.PasswordHash))
    //        return null;

    //    return user;
    //}

    //private string Generate(User user)
    //{
    //    var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
    //    var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

    //    var claims = new[]
    //    {
    //        new Claim(ClaimTypes.NameIdentifier, user.FirstName),
    //        new Claim(ClaimTypes.Email, user.Email),
    //        new Claim(ClaimTypes.Surname, user.Surname)
    //    };

    //    var token = new JwtSecurityToken
    //    (
    //       issuer: _configuration["Jwt:Issuer"],
    //       audience: _configuration["Jwt:Audience"],
    //       claims: claims,
    //       expires: DateTime.UtcNow.AddDays(7),
    //       signingCredentials: credentials
    //    );

    //    return new JwtSecurityTokenHandler().WriteToken(token);
    //}

    
    //public async Task<User> CreateUserAsync(User user)
    //{
    //    await _userRepository.CreateUserAsync(user);
    //    return user;
    //}

    //public async Task<User> GetUserByEmailAsync(string email)
    //{
    //    return await _userRepository.GetUserByEmailAsync(email);
    //}
}
