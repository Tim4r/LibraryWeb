using Library.Core.Dtos;
using Library.Data.Models;

namespace Library.Core.Interfaces;

public interface IBookService
{
    Task<IEnumerable<BookDto>> GetAllBooksAsync();
    Task<BookDto> GetBookByIdAsync(int id);
    Task<BookDto> GetBookByISBNAsync(string ISBN);
    Task<BookDto> CreateBookAsync(BookDto book);
    Task<BookDto> UpdateBookAsync(int id, BookDto book);
}
