﻿using Library.Core.Dtos;

namespace Library.Core.Interfaces;

public interface IBookService
{
    Task<IEnumerable<BookDto>> GetAllBooksAsync(int pageNumber, int pageSize);
    Task<BookDto> GetBookByIdAsync(int id);
    Task<BookDto> GetBookByISBNAsync(string ISBN);
    Task<BookDto> CreateBookAsync(BookDto book);
    Task<BookDto> UpdateBookAsync(int id, BookDto book);
    Task<BookDto> DeleteBookAsync(int id);
    Task<BookLoanDto> HandOutBookAsync(BookLoanDto book);
}
