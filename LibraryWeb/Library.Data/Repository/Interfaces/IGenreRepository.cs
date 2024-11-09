using Library.Data.Models;

namespace Library.Data.Repository.Interfaces;

public interface IGenreRepository
{
    Task<IEnumerable<Genre>> GetAllGenresOfBooksAsync();
}
