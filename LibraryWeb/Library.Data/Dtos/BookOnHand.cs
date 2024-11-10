namespace Library.Core.Dtos;

public class BookOnHand
{
    public string Title { get; set; } = string.Empty;
    public string? Image { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public DateTime ReturnTime { get; set; }
}
