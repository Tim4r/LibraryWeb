using Library.Core.Dtos;

namespace Library.Core.Interfaces;

public interface IBookService
{
    Task<IEnumerable<BookDto>> GetAllBooksAsync(
        int pageNumber, 
        int pageSize,
        int? authorId,
        int? categoryId,
        string? searchQuery);
    Task<IEnumerable<BookDto>> GetAllHandOutBooksAsync();
    Task<IEnumerable<GenreDto>> GetAllGenresOfBooksAsync();
    Task<BookDto> GetBookByIdAsync(int id);
    Task<BookDto> GetBookByISBNAsync(string ISBN);
    Task<BookDto> CreateBookAsync(BookDto book);
    Task<BookDto> UpdateBookAsync(int id, BookDto book);
    Task<BookDto> DeleteBookAsync(int id);
    Task<BookLoanDto> HandOutBookAsync(BookLoanDto book);
    Task<IEnumerable<BookOnHand>> GetBookLoansByUserIdAsync(int userId);
}
