using Library.BL;
using Library.BL.Mapper;
using Library.Core.Dtos;
using Library.Core.Interfaces;
using Library.Core.ViewDtos;
using Library.Data.Models;
using Library.WebAPI.Mapper;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

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
    public async Task<IActionResult> GetAllAuthors()
    {
        try
        {
            var response = await _authorService.GetAllAuthorsAsync();
            var apiResult = ApiResult<IEnumerable<AuthorDto>>.Success(response);
            return Ok(apiResult);
        }
        catch (Exception ex)
        {
            var apiResult = ApiResult<AuthorDto>.Failure(new[] { ex.Message });
            return Problem(detail: JsonSerializer.Serialize(apiResult));
        }
    }

    [HttpGet]
    [Route("~/api/GetAuthorById")]
    public async Task<IActionResult> GetAuthorById(int id)
    {
        try
        {
            var response = await _authorService.GetAuthorByIdAsync(id);
            var apiResult = ApiResult<AuthorDto>.Success(response);
            return Ok(apiResult);
        }
        catch (Exception ex)
        {
            var apiResult = ApiResult<Author>.Failure(new[] { ex.Message });
            return Problem(detail: JsonSerializer.Serialize(apiResult));
        }
    }

    [HttpPost]
    [Route("~/api/CreateAuthor")]
    public async Task<IActionResult> CreateAuthor([FromBody] AuthorViewDto authorViewDto)
    {
        try
        {
            var authorDto = ViewDtoToDtoMapper.Mapper.Map<AuthorDto>(authorViewDto);
            var response = await _authorService.CreateAuthorAsync(authorDto);
            var apiResult = ApiResult<AuthorDto>.Success(response);
            return Ok(apiResult);
        } 
        catch (Exception ex) 
        { 
            var apiResult = ApiResult<AuthorDto>.Failure(new[] { ex.Message });
            return Problem(detail: JsonSerializer.Serialize(apiResult));
        }
    }

    [HttpPost]
    [Route("~/api/UpdateAuthor")]
    public async Task<IActionResult> UpdateAuthor(int id, [FromBody] AuthorViewDto authorViewDto)
    {
        try
        {
            var authorDto = ModelToDtoMapper.Mapper.Map<AuthorDto>(authorViewDto);
            var response = await _authorService.UpdateAuthorAsync(id, authorDto);
            var apiResult = ApiResult<AuthorDto>.Success(response);
            return Ok(apiResult);
        }
        catch (Exception ex)
        {
            var apiResult = ApiResult<AuthorDto>.Failure(new[] { ex.Message });
            return Problem(detail: JsonSerializer.Serialize(apiResult));
        }
    }

    [HttpDelete]
    [Route("~/api/DeleteAuthor")]
    public async Task<IActionResult> DeleteAuthor(int id)
    {
        try
        {
            var response = await _authorService.DeleteAuthorAsync(id);
            var apiResult = ApiResult<AuthorDto>.Success(response);
            return Ok(apiResult);
        }
        catch (Exception ex) 
        {
            var apiResult = ApiResult<AuthorDto>.Failure(new[] { ex.Message });
            return Problem(detail: JsonSerializer.Serialize(apiResult));
        }
    }

    [HttpGet]
    [Route("~/api/GetBooksByAuthor")]
    public async Task<IActionResult> GetBooksByAuthor(int id)
    {
        try
        {
            var response = await _authorService.GetBooksByAuthorAsync(id);
            var apiResult = ApiResult<IEnumerable<BookDto>>.Success(response);
            return Ok(apiResult);
        }
        catch (Exception ex)
        {
            var apiResult = ApiResult<IEnumerable<BookDto>>.Failure(new[] { ex.Message });
            return Problem(detail: JsonSerializer.Serialize(apiResult));
        }
    }
}
