using Library.Data.Models;

namespace Library.Core.ViewDtos;

public class AuthorViewDto
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public DateTime BirthDate { get; set; }
    public string Country { get; set; } = string.Empty;
}
