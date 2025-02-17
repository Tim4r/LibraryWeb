﻿using Library.Data.Context;
using Library.Data.Repository;
using Library.Data.Repository.Interfaces;

namespace Library.Data.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDBContext _context;

    private IBookRepository _books;
    private IAuthorRepository _authors;
    private IGenreRepository _genres;

    public UnitOfWork(ApplicationDBContext context)
    {
        _context = context;
    }

    public IBookRepository Books => _books ??= new BookRepository(_context);
    public IAuthorRepository Authors => _authors ??= new AuthorRepository(_context);
    public IGenreRepository Genres => _genres ??= new GenreRepository(_context);

    public async Task<int> CompleteAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
