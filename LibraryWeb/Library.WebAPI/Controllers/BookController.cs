using Library.Core.Dtos;
using Library.Core.Interfaces;
using Library.Core.ViewDto;
using Library.Core.ViewDtos;
using Library.WebAPI.Mapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BookController : ControllerBase
{
    private readonly IBookService _bookService;

    public BookController(IBookService bookService)
    {
        _bookService = bookService;
    }

    [Authorize(Policy = "AdminOrUser")]
    [HttpGet]
    [Route("~/api/GetAllBooks")]
    public async Task<IActionResult> GetAllBooks(
        int pageNumber = 1, 
        int pageSize = 10,
        int? authorId = null,
        int? genreId = null,
        string? searchQuery = null)
    {
        var response = await _bookService.GetAllBooksAsync(pageNumber, pageSize, authorId, genreId, searchQuery);
        return Ok(response);
    }

    [Authorize(Policy = "AdminOrUser")]
    [HttpGet]
    [Route("~/api/GetAllHandOutBooks")]
    public async Task<IActionResult> GetAllHandOutBooks()
    {
        var response = await _bookService.GetAllHandOutBooksAsync();
        return Ok(response);
    }

    [Authorize(Policy = "AdminOrUser")]
    [HttpGet]
    [Route("~/api/GetAllGenresOfBooks")]
    public async Task<IActionResult> GetAllGenresOfBooks()
    {
        var response = await _bookService.GetAllGenresOfBooksAsync();
        return Ok(response);
    }

    [Authorize(Policy = "AdminOrUser")]
    [HttpGet]
    [Route("~/api/GetBookById")]
    public async Task<IActionResult> GetBookById(int id)
    {
        var response = await _bookService.GetBookByIdAsync(id);
        return Ok(response);
    }

    [Authorize(Policy = "AdminOrUser")]
    [HttpGet]
    [Route("~/api/GetBookByISBN")]
    public async Task<IActionResult> GetBookByISBN(string ISBN)
    {
        var response = await _bookService.GetBookByISBNAsync(ISBN);
        return Ok(response);
    }

    [Authorize(Policy = "AdminOrUser")]
    [HttpGet]
    [Route("~/api/GetBookLoansByUserId")]
    public async Task<IActionResult> GetBookLoansByUserId(int userId)
    {
        var response = await _bookService.GetBookLoansByUserIdAsync(userId);
        return Ok(response);
    }

    [Authorize(Policy = "AdminOnly")]
    [HttpPost]
    [Route("~/api/CreateBook")]
    public async Task<IActionResult> CreateBook([FromBody] BookViewDto bookViewDto)
    {
        var bookDto = ViewDtoToDtoMapper.Mapper.Map<BookDto>(bookViewDto);
        var response = await _bookService.CreateBookAsync(bookDto);
        return Ok(response);
    }

    [Authorize(Policy = "AdminOnly")]
    [HttpPost]
    [Route("~/api/UpdateBook")]
    public async Task<IActionResult> UpdateBook(int id, [FromBody] BookViewDto bookViewDto)
    {
        var bookDto = ViewDtoToDtoMapper.Mapper.Map<BookDto>(bookViewDto);
        var response = await _bookService.UpdateBookAsync(id, bookDto);
        return Ok(response);
      
    }

    [Authorize(Policy = "AdminOnly")]
    [HttpDelete]
    [Route("~/api/DeleteBook")]
    public async Task<IActionResult> DeleteBook(int id)
    {
        var response = await _bookService.DeleteBookAsync(id);
        return Ok(response);
    }

    [Authorize(Policy = "AdminOrUser")]
    [HttpPost]
    [Route("~/api/HandOutBook")]
    public async Task<IActionResult> HandOutBook([FromBody] BookLoanViewDto bookLoanViewDto)
    {
        var bookLoanDto = ViewDtoToDtoMapper.Mapper.Map<BookLoanDto>(bookLoanViewDto);
        var response = await _bookService.HandOutBookAsync(bookLoanDto);
        return Ok(response);
    }
}
