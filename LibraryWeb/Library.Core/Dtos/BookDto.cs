using Library.Data.Models;

namespace Library.Core.Dtos;

public class BookDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string ISBN { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string? Image { get; set; } = string.Empty;
    public int AuthorId { get; set; }
    public int GenreId { get; set; }

    public Author? Author { get; set; }
}
