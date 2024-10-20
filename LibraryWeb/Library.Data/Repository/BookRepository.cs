using Library.Data.Context;
using Library.Data.Models;
using Library.Data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Library.Data.Repository;

public class BookRepository : IBookRepository
{
    private readonly ApplicationDBContext _context;

    public BookRepository(ApplicationDBContext context) => _context = context;

    public async Task<IEnumerable<Book>> GetAllBooksAsync()
    {
        var booksList = await _context.Books.ToListAsync();
        return booksList;
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
        _context.Books.Add(book);
        await _context.SaveChangesAsync();
        return _context.Entry(book).Entity;
    }

    public async Task<Book> UpdateBookAsync(int id, Book book)
    {
        var sourceBook = await _context.Books.FirstOrDefaultAsync(x => x.Id == id);
        sourceBook.Title = book.Title;
        sourceBook.ISBN = book.ISBN;
        sourceBook.Description = book.Description;
        _context.Books.Update(sourceBook);
        await _context.SaveChangesAsync();
        return sourceBook;
    }

    public async Task<Book> DeleteBookAsync(int id)
    {
        var book = _context.Books.FirstOrDefault(x => x.Id == id);
        var deletedBook = _context.Books.Remove(book).Entity;
        await _context.SaveChangesAsync();
        return deletedBook;
    }

    public async Task<BookLoan> CreateBookLoanAsync(BookLoan bookLoan)
    {
        _context.BookLoans.Add(bookLoan);
        await _context.SaveChangesAsync();
        return _context.Entry(bookLoan).Entity;
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }
}
