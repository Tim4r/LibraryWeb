namespace Library.Data.Models;

public class BookLoan
{
    public int Id { get; set; }
    public DateTime TakenTime { get; set; }
    public DateTime ReturnTime { get; set; }
    public int UserCredentialsId { get; set; }
    public ICollection<Book> Books { get; set; }
    public BookLoan() => Books = new List<Book>();
}
