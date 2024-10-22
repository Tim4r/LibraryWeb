using Library.Data.Models;

namespace Library.BL.Services;

public interface IAuthorRepository
{
    Task<IEnumerable<Author>> GetAllAuthorsAsync();
    Task<Author> GetAuthorByIdAsync(int id);
    Task<Author> CreateAuthorAsync(Author author);
    Task SaveChangesAsync();
}
