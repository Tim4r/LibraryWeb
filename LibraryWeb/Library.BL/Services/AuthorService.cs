using Library.BL.Mapper;
using Library.Core.Dtos;
using Library.Core.Interfaces;
using Library.Core.UnitOfWork;
using Library.Data.Models;

namespace Library.BL.Services;

public class AuthorService : IAuthorService
{
    private readonly IUnitOfWork _unitOfWork;
    public AuthorService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<AuthorDto>> GetAllAuthorsAsync(int pageNumber, int pageSize)
    {
        var authors = await _unitOfWork.Authors.GetAllAuthorsAsync(pageNumber, pageSize);
        return ModelToDtoMapper.Mapper.Map<IEnumerable<AuthorDto>>(authors);
    }

    public async Task<AuthorDto> GetAuthorByIdAsync(int id)
    {
        var author = await _unitOfWork.Authors.GetAuthorByIdAsync(id);
        return ModelToDtoMapper.Mapper.Map<AuthorDto>(author);
    }

    public async Task<AuthorDto> CreateAuthorAsync(AuthorDto author)
    {
        var authorToCreate = ModelToDtoMapper.Mapper.Map<Author>(author);
        await _unitOfWork.Authors.CreateAuthorAsync(authorToCreate);
        await _unitOfWork.Authors.SaveChangesAsync();
        return author;
    }

    public async Task<AuthorDto> UpdateAuthorAsync(int id,  AuthorDto author)
    {
        var authorToUpdate = ModelToDtoMapper.Mapper.Map<Author>(author);
        await _unitOfWork.Authors.UpdateAuthorAsync(id, authorToUpdate);
        await _unitOfWork.Authors.SaveChangesAsync();
        return author;
    }

    public async Task<AuthorDto> DeleteAuthorAsync(int id)
    {
        var authorForDelete = await _unitOfWork.Authors.DeleteAuthorAsync(id);
        await _unitOfWork.Authors.SaveChangesAsync();
        return ModelToDtoMapper.Mapper.Map<AuthorDto>(authorForDelete); 
    }

    public async Task<IEnumerable<BookDto>> GetBooksByAuthorAsync(int id)
    {
        var booksOfAuthor = await _unitOfWork.Authors.GetBooksByAuthorAsync(id);
        return ModelToDtoMapper.Mapper.Map<IEnumerable<BookDto>>(booksOfAuthor);
    }
}