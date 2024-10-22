﻿using Library.BL.Mapper;
using Library.Core.Dtos;
using Library.Core.Interfaces;
using Library.Data.Context;
using Library.Data.Models;
using Library.Data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

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

        if (!string.IsNullOrEmpty(book.Image))
        {
            string imagePath = SaveImage(book.Image);
            bookToCreate.Image = imagePath;
        }

        await _bookRepository.CreateBookAsync(bookToCreate);
        await _bookRepository.SaveChangesAsync();
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

        var updatedBook = await _bookRepository.UpdateBookAsync(id, bookToUpdate);
        await _bookRepository.SaveChangesAsync();
        return ModelToDtoMapper.Mapper.Map<BookDto>(updatedBook);
    }

    public async Task<BookDto> DeleteBookAsync(int id)
    {
        var bookForDelete = await _bookRepository.DeleteBookAsync(id);
        await _bookRepository.SaveChangesAsync();
        return ModelToDtoMapper.Mapper.Map<BookDto>(bookForDelete);
    }

    public async Task<BookLoanDto> HandOutBookAsync(BookLoanDto bookLoan)
    {
        var bookExists = await _context.Books.AnyAsync(b => b.Id == bookLoan.BookId);
        if (!bookExists)
        {
            throw new ArgumentException("Book with the provided ID does not exist.");
        }

        var userExists = await _context.Users.AnyAsync(u => u.Id == bookLoan.UserId);
        if (!userExists)
        {
            throw new ArgumentException("User with the provided ID does not exist.");
        }

        var isBookLoaned = await _context.BookLoans.AnyAsync(bl => bl.BookId == bookLoan.BookId);
        if (isBookLoaned)
        {
            throw new InvalidOperationException("The book is currently loaned out.");
        }

        var newBookLoan = ModelToDtoMapper.Mapper.Map<BookLoan>(bookLoan);
        newBookLoan.TakenTime = DateTime.Now;

        await _bookRepository.CreateBookLoanAsync(newBookLoan);
        await _bookRepository.SaveChangesAsync();

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
