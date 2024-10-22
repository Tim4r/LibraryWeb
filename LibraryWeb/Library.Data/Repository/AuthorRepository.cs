using Library.BL.Services;
using Library.Data.Context;
using Library.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Data.Repository;

public class AuthorRepository : IAuthorRepository
{
    private readonly ApplicationDBContext _context;
    public AuthorRepository(ApplicationDBContext context) => _context = context;

    public async Task<IEnumerable<Author>> GetAllAuthorsAsync()
    {
        return await _context.Authors.ToListAsync();
    }

    public async Task<Author> GetAuthorByIdAsync(int id)
    {
        return await _context.Authors.FindAsync(id);
    }

    public async Task<Author> CreateAuthorAsync(Author author)
    {
        await _context.Authors.AddAsync(author);
        return _context.Entry(author).Entity;
    }

    public Task SaveChangesAsync()
    {
        return _context.SaveChangesAsync();
    }
}
