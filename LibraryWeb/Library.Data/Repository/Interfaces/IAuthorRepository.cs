using Library.Data.Models;

namespace Library.Data.Repository.Interfaces;

public interface IAuthorRepository
{
    Task<IEnumerable<Author>> GetAllAuthorsAsync(int pageNumber, int pageSize);
    Task<Author> GetAuthorByIdAsync(int id);
    Task<Author> CreateAuthorAsync(Author author);
    Task<Author> UpdateAuthorAsync(int id, Author author);
    Task<Author> DeleteAuthorAsync(int id);
    Task<IEnumerable<Book>> GetBooksByAuthorAsync(int authorId);
}
