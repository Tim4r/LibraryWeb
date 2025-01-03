﻿using Library.Data.Context;
using Library.Data.Models;
using Library.Data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Library.Data.Repository;

public class AuthorRepository : IAuthorRepository
{
    private readonly ApplicationDBContext _context;
    public AuthorRepository(ApplicationDBContext context) => _context = context;

    public async Task<IEnumerable<Author>> GetAllAuthorsAsync(int pageNumber, int pageSize)
    {
        return await _context.Authors
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
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

    public async Task<Author> UpdateAuthorAsync(int id, Author author)
    {
        var sourceAuthor = await _context.Authors.FirstOrDefaultAsync(x => x.Id == id);

        if (sourceAuthor != null)
        {
            sourceAuthor.FirstName = author.FirstName;
            sourceAuthor.LastName = author.LastName;
            sourceAuthor.BirthDate = author.BirthDate;
            sourceAuthor.Country = author.Country;
        }
        return author;
    }

    public async Task<Author> DeleteAuthorAsync(int id)
    {
        var author = await _context.Authors.FirstOrDefaultAsync(x => x.Id == id);
        var deletedAuthor = _context.Authors.Remove(author).Entity;
        return deletedAuthor;
    }

    public async Task<IEnumerable<Book>> GetBooksByAuthorAsync(int id)
    {
        var books = await _context.Books
            .Where(x => x.AuthorId == id)
            .ToListAsync();
        return books;
    }
}
