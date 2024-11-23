namespace Library.Core.Dtos;

public class BookLoanDto
{
    public int Id { get; set; }
    public DateTime TakenTime { get; set; }
    public DateTime ReturnTime { get; set; }
    public int UserId { get; set; }
    public int BookId { get; set; }
}
