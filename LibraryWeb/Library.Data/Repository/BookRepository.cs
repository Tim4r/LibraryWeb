using Library.Core.Dtos;
using Library.Data.Context;
using Library.Data.Models;
using Library.Data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Library.Data.Repository;

public class BookRepository : IBookRepository
{
    private readonly ApplicationDBContext _context;

    public BookRepository(ApplicationDBContext context) => _context = context;

    public async Task<IEnumerable<Book>> GetAllBooksAsync(
        int pageNumber, 
        int pageSize,
        int? authorId,
        int? categoryId,
        string? searchQuery)
    {
        var query = _context.Books.AsQueryable();

        if (authorId.HasValue)
            query = query.Where(b => b.AuthorId == authorId.Value);

        if (categoryId.HasValue)
            query = query.Where(b => b.GenreId == categoryId.Value);

        if (!string.IsNullOrEmpty(searchQuery))
            query = query.Where(b => b.Title.Contains(searchQuery));

        var booksList = await query
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return booksList;
    }

    public async Task<IEnumerable<Book>> GetAllHandOutBooksAsync()
    {
        var bookList = await _context.Books
            .Where(b => b.BookLoan != null)
            .ToListAsync();

        return bookList;
    }

    public async Task<Book> GetBookByIdAsync(int id)
    {
        var book = await _context.Books.FindAsync(id);
        return book;
    }

    public async Task<Book> GetBookByISBNAsync(string ISBN)
    {
        var book = await _context.Books.FirstOrDefaultAsync(x => x.ISBN == ISBN);
        return book;
    }

    public async Task<Book> CreateBookAsync(Book book)
    {
        await _context.Books.AddAsync(book);
        return _context.Entry(book).Entity;
    }

    public async Task<Book> UpdateBookAsync(int id, Book book)
    {
        var sourceBook = await _context.Books.FirstOrDefaultAsync(x => x.Id == id);

        if (sourceBook != null)
        {
            sourceBook.Title = book.Title;
            sourceBook.ISBN = book.ISBN;
            sourceBook.Description = book.Description;
        }
        return book;
    }

    public async Task<Book> DeleteBookAsync(int id)
    {
        var book = await _context.Books.FirstOrDefaultAsync(x => x.Id == id);
        var deletedBook = _context.Books.Remove(book).Entity;
        return deletedBook;
    }

    public async Task<BookLoan> CreateBookLoanAsync(BookLoan bookLoan)
    {
        await _context.BookLoans.AddAsync(bookLoan);
        return _context.Entry(bookLoan).Entity;
    }

    public async Task<IEnumerable<BookOnHand>> GetBookLoansByUserIdAsync(int userId)
    {
        var bookLoans = await _context.BookLoans
            .Where(bl => bl.UserId == userId)
            .Select(bl => new BookOnHand
            {
                Title = bl.Book.Title,
                Image = bl.Book.Image,
                FirstName = bl.Book.Author.FirstName,
                LastName = bl.Book.Author.LastName,
                ReturnTime = bl.ReturnTime
            })
            .ToListAsync();
        return bookLoans;
    }

    public Task SaveChangesAsync()
    {
        return _context.SaveChangesAsync();
    }
}
