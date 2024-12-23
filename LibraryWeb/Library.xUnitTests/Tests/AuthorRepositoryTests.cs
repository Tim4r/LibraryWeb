using Library.Data.Context;
using Library.Data.Models;
using Library.Data.Repository;
using Microsoft.EntityFrameworkCore;

namespace Library.WebAPI.Tests;

public class AuthorRepositoryTests
{
    private readonly ApplicationDBContext _context;
    private readonly AuthorRepository _repository;

    public AuthorRepositoryTests()
    {
        var options = new DbContextOptionsBuilder<ApplicationDBContext>()
            .UseInMemoryDatabase(databaseName: "AuthorRepositoryTests")
            .Options;

        _context = new ApplicationDBContext(options);
        _repository = new AuthorRepository(_context);

        SeedData();
    }

    private void SeedData()
    {
        _context.Authors.AddRange(
            new Author { FirstName = "John", LastName = "Doe" },
            new Author { FirstName = "Jane", LastName = "Smith" }
        );
        _context.SaveChanges();
    }

    [Fact]
    public async Task GetAllAuthorsAsync_ReturnsAllAuthors()
    {
        var result = await _repository.GetAllAuthorsAsync(1, 10);

        Assert.Equal(2, result.Count());
    }

    [Fact]
    public async Task GetAuthorByIdAsync_ReturnsCorrectAuthor()
    {
        var result = await _repository.GetAuthorByIdAsync(1);

        Assert.NotNull(result);
        Assert.Equal("John", result.FirstName);
    }
}
