using Library.BL.Mapper;
using Library.Core.Dtos;
using Library.Core.Interfaces;
using Library.Data.Models;

namespace Library.BL.Services;

public class AuthorService : IAuthorService
{
    private readonly IAuthorRepository _authorRepository;
    public AuthorService(IAuthorRepository authorRepository)
    {
        _authorRepository = authorRepository;
    }

    public async Task<IEnumerable<AuthorDto>> GetAllAuthorsAsync()
    {
        var authors = await _authorRepository.GetAllAuthorsAsync();
        return ModelToDtoMapper.Mapper.Map<IEnumerable<AuthorDto>>(authors);
    }

    public async Task<AuthorDto> GetAuthorByIdAsync(int id)
    {
        var author = await _authorRepository.GetAuthorByIdAsync(id);
        return ModelToDtoMapper.Mapper.Map<AuthorDto>(author);
    }

    public async Task<AuthorDto> CreateAuthorAsync(AuthorDto author)
    {
        var authorToCreate = ModelToDtoMapper.Mapper.Map<Author>(author);
        await _authorRepository.CreateAuthorAsync(authorToCreate);
        await _authorRepository.SaveChangesAsync();
        return author;
    }

    public async Task<AuthorDto> UpdateAuthorAsync(int id,  AuthorDto author)
    {
        var authorToUpdate = ModelToDtoMapper.Mapper.Map<Author>(author);
        await _authorRepository.UpdateAuthorAsync(id, authorToUpdate);
        await _authorRepository.SaveChangesAsync();
        return author;
    }

    public async Task<AuthorDto> DeleteAuthorAsync(int id)
    {
        var authorForDelete = await _authorRepository.DeleteAuthorAsync(id);
        await _authorRepository.SaveChangesAsync();
        return ModelToDtoMapper.Mapper.Map<AuthorDto>(authorForDelete); 
    }
    public async Task<IEnumerable<BookDto>> GetBooksByAuthorAsync(int id)
    {
        var booksOfAuthor = await _authorRepository.GetBooksByAuthorAsync(id);
        return ModelToDtoMapper.Mapper.Map<IEnumerable<BookDto>>(booksOfAuthor);
    }
}