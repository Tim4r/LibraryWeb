using Library.BL.Mapper;
using Library.Core.Dtos;
using Library.Core.Interfaces;
using Library.Data;
using Library.Data.Models;
using Library.Data.Repository.Interfaces;

namespace Library.BL.Services;

public class BookService : IBookService
{
    private readonly ApplicationDBContext _context;
    private readonly IBookRepository _bookRepository;
    public BookService(ApplicationDBContext context, IBookRepository bookRepository)
    {
        _context = context;
        _bookRepository = bookRepository;
    }
    public async Task<IEnumerable<BookDto>> GetAllBooksAsync()
    {
        var books = await _bookRepository.GetAllBooksAsync();
        return ModelToDtoMapper.Mapper.Map<IEnumerable<BookDto>>(books);
    }

    public async Task<BookDto> GetBookByIdAsync(int id)
    {
        var book = await _bookRepository.GetBookByIdAsync(id);
        return ModelToDtoMapper.Mapper.Map<BookDto>(book);
    }

    public async Task<BookDto> GetBookByISBNAsync(string ISBN)
    {
        var book = await _bookRepository.GetBookByISBNAsync(ISBN);
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

        await _bookRepository.CreateBookAsync(bookToCreate);
        _bookRepository.SaveChanges();
        return ModelToDtoMapper.Mapper.Map<BookDto>(_context.Entry(bookToCreate).Entity);
    }

    public async Task<BookDto> UpdateBookAsync(int id, BookDto book)
    {
        var bookToUpdate = ModelToDtoMapper.Mapper.Map<Book>(book);
        var updatedBook = await _bookRepository.UpdateBookAsync(id, bookToUpdate);
        return ModelToDtoMapper.Mapper.Map<BookDto>(updatedBook);
    }

    public async Task<BookDto> DeleteBookAsync(int id)
    {
        var bookForDelete = await _bookRepository.DeleteBookAsync(id);
        return ModelToDtoMapper.Mapper.Map<BookDto>(bookForDelete);
    }
}
