using Library.BL.Services;
using Library.Core.Dtos;
using Library.Core.UnitOfWork;
using Library.Data.Models;
using Moq;

namespace Library.WebAPI.Tests;

public class AuthorServiceTests
{
    private readonly Mock<IUnitOfWork> _mockUnitOfWork;
    private readonly AuthorService _service;

    public AuthorServiceTests()
    {
        _mockUnitOfWork = new Mock<IUnitOfWork>();
        _service = new AuthorService(_mockUnitOfWork.Object);
    }

    [Fact]
    public async Task GetAllAuthorsAsync_ReturnsListOfAuthorDtos()
    {
        // Arrange
        var authors = new List<Author> { new Author { Id = 1, FirstName = "John", LastName = "Doe" } };
        _mockUnitOfWork.Setup(uow => uow.Authors.GetAllAuthorsAsync(1, 10)).ReturnsAsync(authors);

        // Act
        var result = await _service.GetAllAuthorsAsync(1, 10);

        // Assert
        Assert.NotNull(result);
        Assert.Single(result);
    }

    [Fact]
    public async Task CreateAuthorAsync_CreatesAndReturnsAuthorDto()
    {
        // Arrange
        var authorDto = new AuthorDto { FirstName = "Jane", LastName = "Doe" };
        var author = new Author { Id = 1, FirstName = "Jane", LastName = "Doe" };

        _mockUnitOfWork.Setup(uow => uow.Authors.CreateAuthorAsync(It.IsAny<Author>())).ReturnsAsync(author);
        _mockUnitOfWork.Setup(uow => uow.Authors.SaveChangesAsync()).Returns(Task.CompletedTask);

        // Act
        var result = await _service.CreateAuthorAsync(authorDto);

        // Assert
        Assert.Equal("Jane", result.FirstName);
    }
}
