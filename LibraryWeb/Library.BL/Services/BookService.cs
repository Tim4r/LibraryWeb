using Library.BL.Mapper;
using Library.Core.Dtos;
using Library.Core.Interfaces;
using Library.Core.UnitOfWork;
using Library.Data.Context;
using Library.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Library.BL.Services;

public class BookService : IBookService
{
    private readonly IConfiguration _configuration;
    private readonly ApplicationDBContext _context;
    
    private readonly IUnitOfWork _unitOfWork;
    public BookService(ApplicationDBContext context, IConfiguration configuration, IUnitOfWork unitOfWork)
    {
        _context = context;
        _configuration = configuration;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<BookDto>> GetAllBooksAsync(
        int pageNumber, 
        int pageSize, 
        int? authorId, 
        int? categoryId, 
        string? searchQuery)
    {
        var books = await _unitOfWork.Books.GetAllBooksAsync(pageNumber, pageSize, authorId, categoryId, searchQuery);
        return ModelToDtoMapper.Mapper.Map<IEnumerable<BookDto>>(books);
    }

    public async Task<IEnumerable<BookDto>> GetAllHandOutBooksAsync()
    {
        var books = await _unitOfWork.Books.GetAllHandOutBooksAsync();
        return ModelToDtoMapper.Mapper.Map<IEnumerable<BookDto>>(books);
    }

    public async Task<IEnumerable<GenreDto>> GetAllGenresOfBooksAsync()
    {
        var genres = await _unitOfWork.Genres.GetAllGenresOfBooksAsync();
        return ModelToDtoMapper.Mapper.Map<IEnumerable<GenreDto>>(genres);
    }

    public async Task<BookDto> GetBookByIdAsync(int id)
    {
        var book = await _unitOfWork.Books.GetBookByIdAsync(id);
        return ModelToDtoMapper.Mapper.Map<BookDto>(book);
    }

    public async Task<BookDto> GetBookByISBNAsync(string ISBN)
    {
        var book = await _unitOfWork.Books.GetBookByISBNAsync(ISBN);
        return ModelToDtoMapper.Mapper.Map<BookDto>(book);
    }

    public async Task<BookDto> CreateBookAsync(BookDto book)
    {
        var bookToCreate = ModelToDtoMapper.Mapper.Map<Book>(book);

        if (!_context.Authors.Any(a => a.Id == bookToCreate.AuthorId))
        {
            throw new ArgumentException("Author with this ID does not exist");
        }

        if (!_context.Genres.Any(c => c.Id == bookToCreate.GenreId))
        {
            throw new ArgumentException("Genre with this ID does not exist");
        }

        if (!string.IsNullOrEmpty(book.Image))
        {
            string imagePath = SaveImage(book.Image);
            bookToCreate.Image = imagePath;
        }

        await _unitOfWork.Books.CreateBookAsync(bookToCreate);
        await _unitOfWork.Books.SaveChangesAsync();
        return book;
    }

    public async Task<BookDto> UpdateBookAsync(int id, BookDto book)
    {
        var bookToUpdate = ModelToDtoMapper.Mapper.Map<Book>(book);

        if(!string.IsNullOrEmpty(book.Image)) 
        {
            string imagePath = SaveImage(book.Image);
            bookToUpdate.Image = imagePath;
        }

        await _unitOfWork.Books.UpdateBookAsync(id, bookToUpdate);
        await _unitOfWork.Books.SaveChangesAsync();
        return book;
    }

    public async Task<BookDto> DeleteBookAsync(int id)
    {
        var bookForDelete = await _unitOfWork.Books.DeleteBookAsync(id);
        await _unitOfWork.Books.SaveChangesAsync();
        return ModelToDtoMapper.Mapper.Map<BookDto>(bookForDelete);
    }

    public async Task<BookLoanDto> HandOutBookAsync(BookLoanDto bookLoan)
    {
        DateTime returnBookDate = bookLoan.ReturnTime;
        DateTime dateTimeNow = DateTime.UtcNow;

        TimeSpan timeDiff = returnBookDate - dateTimeNow;
        int daysBeforeReturn = timeDiff.Days;

        if (daysBeforeReturn <= 1)
            throw new ArgumentException("Incorrect date! (The return date must be no earlier than one day from the date of receipt of the book)");

        if (daysBeforeReturn > 30)
            throw new ArgumentException("Incorrect date! (The return date must be no later than thirty days from the date the book was taken)");

        var isBookLoaned = await _context.BookLoans.AnyAsync(bl => bl.BookId == bookLoan.BookId);
        if (isBookLoaned)
            throw new InvalidOperationException("The book is currently loaned out!");

        var userExist = await _context.Users.AnyAsync(u => u.Id == bookLoan.UserId);
        if (!userExist)
            throw new ArgumentException("The author you entered doesn't exist!");

        var bookExist = await _context.Books.AnyAsync(b => b.Id == bookLoan.BookId);
        if (!bookExist)
            throw new ArgumentException("The book you entered doesn't exist!");

        var newBookLoan = ModelToDtoMapper.Mapper.Map<BookLoan>(bookLoan);
        newBookLoan.TakenTime = DateTime.Now;

        await _unitOfWork.Books.CreateBookLoanAsync(newBookLoan);
        await _unitOfWork.Books.SaveChangesAsync();

        return ModelToDtoMapper.Mapper.Map<BookLoanDto>(newBookLoan);
    }

    public async Task<IEnumerable<BookOnHand>> GetBookLoansByUserIdAsync(int userId)
    {
        var bookLoans = await _unitOfWork.Books.GetBookLoansByUserIdAsync(userId);
        if (bookLoans == null || !bookLoans.Any())
            throw new InvalidOperationException("You don't have any books.");
        return bookLoans;
    }

    public string SaveImage(string base64Image)
    {
        var imageBytes = Convert.FromBase64String(base64Image);

        var fileName = $"{Guid.NewGuid()}.jpg";
        var filePath = Path.Combine("wwwroot", "Images", "BookCovers", fileName);

        File.WriteAllBytes(filePath, imageBytes);

        var baseUrl = _configuration["BaseUrl"];

        return $"{baseUrl}/Images/BookCovers/{fileName}";
    }
}
