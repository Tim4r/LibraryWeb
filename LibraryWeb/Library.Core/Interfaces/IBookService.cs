using Library.Core.Dtos;

namespace Library.Core.Interfaces;

public interface IBookService
{
    Task<IEnumerable<BookDto>> GetAllBooksAsync();
}
