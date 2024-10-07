using Library.BL;
using Library.Core.Dtos;
using Library.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Library.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class BookController : ControllerBase
{
    private readonly IBookService _bookService;

    public BookController(IBookService bookService)
    {
        _bookService = bookService;
    }

    [Route("~/api/GetAllBooks")]
    [HttpGet]
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
}
