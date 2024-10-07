namespace Library.Data.Models;

public class Category
{
    public int Id { get; set; }
    public string Genre { get; set; } = string.Empty;
    public ICollection<Book> Books { get; set; }
    public Category() => Books = new List<Book>();
}
