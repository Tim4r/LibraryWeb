using Library.Data.Models;

namespace Library.Data.Repository.Interfaces;

public interface IBookRepository
{
    Task<IEnumerable<Book>> GetAllBooksAsync(int pageNumber, int pageSize);
    Task<Book> GetBookByIdAsync(int id);
    Task<Book> GetBookByISBNAsync(string ISBN);
    Task<Book> CreateBookAsync(Book book);
    Task<Book> UpdateBookAsync(int id, Book book);
    Task<Book> DeleteBookAsync(int id);
    Task<BookLoan> CreateBookLoanAsync(BookLoan bookLoan);
    
    Task SaveChangesAsync();
}
