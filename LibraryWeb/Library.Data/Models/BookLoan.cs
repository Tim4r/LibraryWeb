namespace Library.Data.Models;

public class BookLoan
{
    public int Id { get; set; }
    public DateTime TakenTime { get; set; }
    public DateTime ReturnTime { get; set; }
    public int UserId { get; set; }
    public int BookId { get; set; }
}
