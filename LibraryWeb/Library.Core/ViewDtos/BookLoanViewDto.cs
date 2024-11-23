namespace Library.Core.ViewDtos;

public class BookLoanViewDto
{
    public DateTime ReturnTime { get; set; }
    public int UserId { get; set; }
    public int BookId { get; set; }
}
