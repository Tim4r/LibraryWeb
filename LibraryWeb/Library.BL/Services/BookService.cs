using Library.BL.Mapper;
using Library.Core.Dtos;
using Library.Core.Interfaces;
using Library.Core.UnitOfWork;
using Library.Data.Context;
using Library.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.BL.Services;

public class BookService : IBookService
{
    private readonly ApplicationDBContext _context;
    
    private readonly IUnitOfWork _unitOfWork;
    public BookService(ApplicationDBContext context, IUnitOfWork unitOfWork)
    {
        _context = context;
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
            throw new ArgumentException("Author with ID does not exist");
        }

        if (!_context.Categories.Any(c => c.Id == bookToCreate.CategoryId))
        {
            throw new ArgumentException("Category with ID does not exist");
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
        var bookExists = await _context.Books.AnyAsync(b => b.Id == bookLoan.BookId);
        if (!bookExists)
        {
            throw new ArgumentException("Book with the provided ID does not exist.");
        }

        var isBookLoaned = await _context.BookLoans.AnyAsync(bl => bl.BookId == bookLoan.BookId);
        if (isBookLoaned)
        {
            throw new InvalidOperationException("The book is currently loaned out.");
        }

        var newBookLoan = ModelToDtoMapper.Mapper.Map<BookLoan>(bookLoan);
        newBookLoan.TakenTime = DateTime.Now;

        await _unitOfWork.Books.CreateBookLoanAsync(newBookLoan);
        await _unitOfWork.Books.SaveChangesAsync();

        return ModelToDtoMapper.Mapper.Map<BookLoanDto>(newBookLoan);
    }

    public string SaveImage(string base64Image)
    {
        var imageBytes = Convert.FromBase64String(base64Image);

        var fileName = $"{Guid.NewGuid()}.jpg";
        var filePath = Path.Combine("Images", "BookCovers", fileName);

        File.WriteAllBytes(filePath, imageBytes);

        return $"/Images/BookCovers/{fileName}";
    }
}
