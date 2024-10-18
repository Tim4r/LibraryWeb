namespace Library.Data.Models;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string ISBN { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string? Image { get; set; } = string.Empty;
    public int AuthorId { get; set; }
    public int CategoryId { get; set; }
    public ICollection<BookLoan> BookLoans { get; set; }
    public Book() => BookLoans = new List<BookLoan>();
}
