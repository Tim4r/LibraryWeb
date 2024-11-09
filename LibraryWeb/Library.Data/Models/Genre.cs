namespace Library.Data.Models;

public class Genre
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public ICollection<Book> Books { get; set; }
    public Genre() => Books = new List<Book>();
}
