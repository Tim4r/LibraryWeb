using Library.BL.Mapper;
using Library.Core.Dtos;
using Library.Core.Interfaces;
using Library.Core.ViewDtos;
using Library.WebAPI.Mapper;
using Microsoft.AspNetCore.Mvc;

namespace Library.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthorController : ControllerBase
{
    private readonly IAuthorService _authorService;

    public AuthorController(IAuthorService authorService)
    {
        _authorService = authorService;
    }

    [HttpGet]
    [Route("~/api/GetAllAuthors")]
    public async Task<IActionResult> GetAllAuthors(int pageNumber = 1, int pageSize = 10)
    {
        var response = await _authorService.GetAllAuthorsAsync(pageNumber, pageSize);
        return Ok(response);
    }

    [HttpGet]
    [Route("~/api/GetAuthorById")]
    public async Task<IActionResult> GetAuthorById(int id)
    {
        var response = await _authorService.GetAuthorByIdAsync(id);
        return Ok(response);
    }

    [HttpPost]
    [Route("~/api/CreateAuthor")]
    public async Task<IActionResult> CreateAuthor([FromBody] AuthorViewDto authorViewDto)
    {
        var authorDto = ViewDtoToDtoMapper.Mapper.Map<AuthorDto>(authorViewDto);
        var response = await _authorService.CreateAuthorAsync(authorDto);
        return Ok(response);
    }

    [HttpPost]
    [Route("~/api/UpdateAuthor")]
    public async Task<IActionResult> UpdateAuthor(int id, [FromBody] AuthorViewDto authorViewDto)
    {
        var authorDto = ModelToDtoMapper.Mapper.Map<AuthorDto>(authorViewDto);
        var response = await _authorService.UpdateAuthorAsync(id, authorDto);
        return Ok(response);
    }

    [HttpDelete]
    [Route("~/api/DeleteAuthor")]
    public async Task<IActionResult> DeleteAuthor(int id)
    {
        var response = await _authorService.DeleteAuthorAsync(id);
        return Ok(response);
    }

    [HttpGet]
    [Route("~/api/GetBooksByAuthor")]
    public async Task<IActionResult> GetBooksByAuthor(int id)
    {
        var response = await _authorService.GetBooksByAuthorAsync(id);
        return Ok(response);
    }
}
