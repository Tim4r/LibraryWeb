namespace Library.Data.Models;

public class User
{
    public int Id { get; set; }
    public string Login { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public ICollection<BookLoan> BookLoans { get; set; }
    public User() => BookLoans = new List<BookLoan>();
}
