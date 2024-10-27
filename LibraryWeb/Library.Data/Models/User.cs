using Microsoft.AspNetCore.Identity;

namespace Library.Data.Models;

public class User : IdentityUser<int>
{
    public override int Id { get; set; } 
    public override string? UserName { get; set; } = string.Empty;
    public override string? PasswordHash { get; set; } = string.Empty;
    public string PasswordSalt {  get; set; } = string.Empty;
    public override string? Email { get; set; } = string.Empty;
    public ICollection<BookLoan> BookLoans { get; set; }
    public User() => BookLoans = new List<BookLoan>();
}
