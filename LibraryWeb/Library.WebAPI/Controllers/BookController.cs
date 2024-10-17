using Library.BL;
using Library.Core.Dtos;
using Library.Core.Interfaces;
using Library.Core.ViewDto;
using Library.WebAPI.Mapper;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

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

    [HttpGet]
    [Route("~/api/GetAllBooks")]
    public async Task<IActionResult> GetAllBooks()
    {
        try
        {
            var response = await _bookService.GetAllBooksAsync();
            var apiResult = ApiResult<IEnumerable<BookDto>>.Success(response);
            return Ok(apiResult);
        }
        catch (Exception ex)
        {
            var apiResult = ApiResult<BookDto>.Failure(new[] { ex.Message });
            return Problem(detail: JsonSerializer.Serialize(apiResult));
        }
    }

    [HttpGet]
    [Route("~/api/GetBookById")]
    public async Task<IActionResult> GetBookById(int id)
    {
        try
        {
            var response = await _bookService.GetBookByIdAsync(id);
            var apiResult = ApiResult<BookDto>.Success(response);
            return Ok(apiResult);
        }
        catch (Exception ex)
        {
            var apiResult = ApiResult<BookDto>.Failure(new[] { ex.Message });
            return Problem(detail: JsonSerializer.Serialize(apiResult));
        }
    }

    [HttpGet]
    [Route("~/api/GetBookByISBN")]
    public async Task<IActionResult> GetBookByISBN(string ISBN)
    {
        try
        {
            var response = await _bookService.GetBookByISBNAsync(ISBN);
            var apiResult = ApiResult<BookDto>.Success(response);
            return Ok(apiResult);
        }
        catch (Exception ex)
        {
            var apiResult = ApiResult<BookDto>.Failure(new[] { ex.Message });
            return Problem(detail: JsonSerializer.Serialize(apiResult));
        }
    }

    [HttpPost]
    [Route("~/api/CreateBook")]
    public async Task<IActionResult> CreateBook([FromBody] BookViewDto bookViewDto)
    {
        try
        {
            var book = ViewDtoToDtoMapper.Mapper.Map<BookDto>(bookViewDto);
            var response = await _bookService.CreateBookAsync(book);
            var apiResult = ApiResult<BookDto>.Success(response);
            return Ok(apiResult);
        }
        catch (Exception ex)
        {
            var apiResult = ApiResult<BookDto>.Failure(new[] { ex.Message });
            return Problem(detail: JsonSerializer.Serialize(apiResult));
        }
    }

    [HttpPost]
    [Route("~/api/UpdateBook")]
    public async Task<IActionResult> UpdateBook(int id, [FromBody] BookViewDto bookViewDto)
    {
        try
        {
            var book = ViewDtoToDtoMapper.Mapper.Map<BookDto>(bookViewDto);
            var response = await _bookService.UpdateBookAsync(id, book);
            var apiResult = ApiResult<BookDto>.Success(response);
            return Ok(apiResult);
        }
        catch (Exception ex)
        {
            var apiResult = ApiResult<BookDto>.Failure(new[] { ex.Message });
            return Problem(detail: JsonSerializer.Serialize(apiResult));
        }
    }

    [HttpDelete]
    [Route("~/api/DeleteBook")]
    public async Task<IActionResult> DeleteBook(int id)
    {
        try
        {
            var response = await _bookService.DeleteBookAsync(id);
            var apiResult = ApiResult<BookDto>.Success(response);
            return Ok(apiResult);
        }
        catch (Exception ex)
        {
            var apiResult = ApiResult<BookDto>.Failure(new[] { ex.Message });
            return Problem(detail: JsonSerializer.Serialize(apiResult));
        }
    }

    
}
