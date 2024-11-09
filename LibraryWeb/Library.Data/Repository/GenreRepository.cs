using Library.Data.Context;
using Library.Data.Models;
using Library.Data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Library.Data.Repository;

public class GenreRepository : IGenreRepository
{
    private readonly ApplicationDBContext _context;

    public GenreRepository(ApplicationDBContext context) => _context = context;

    public async Task<IEnumerable<Genre>> GetAllGenresOfBooksAsync()
    {
        var genres = await _context.Genres.ToListAsync();
        return genres;
    }
}
