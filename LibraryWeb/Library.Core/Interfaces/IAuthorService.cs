﻿using Library.Core.Dtos;

namespace Library.Core.Interfaces;

public interface IAuthorService
{
    Task<IEnumerable<AuthorDto>> GetAllAuthorsAsync();
    Task<AuthorDto> GetAuthorByIdAsync(int id);
    Task<AuthorDto> CreateAuthorAsync(AuthorDto author);
    Task<AuthorDto> UpdateAuthorAsync(int id, AuthorDto author);
    Task<AuthorDto> DeleteAuthorAsync(int id);
}