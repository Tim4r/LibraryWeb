using Library.Data.Models;

namespace Library.BL.Services;

public interface IAuthorRepository
{
    Task<IEnumerable<Author>> GetAllAuthorsAsync();
    Task<Author> GetAuthorByIdAsync(int id);
    Task<Author> CreateAuthorAsync(Author author);
    Task<Author> UpdateAuthorAsync(int id, Author author);
    Task<Author> DeleteAuthorAsync(int id);
    Task<IEnumerable<Book>> GetBooksByAuthorAsync(int authorId);
    Task SaveChangesAsync();
}
