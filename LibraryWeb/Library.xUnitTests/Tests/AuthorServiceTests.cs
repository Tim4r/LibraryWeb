using Library.BL.Services;
using Library.Core.Dtos;
using Library.Data.Models;
using Library.Data.UnitOfWork;
using Moq;

namespace Library.xUnitTests.Tests;

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
        var authors = new List<Author> { new Author { Id = 1, FirstName = "John", LastName = "Doe" } };
        _mockUnitOfWork.Setup(uow => uow.Authors.GetAllAuthorsAsync(1, 10)).ReturnsAsync(authors);

        var result = await _service.GetAllAuthorsAsync(1, 10);

        Assert.NotNull(result);
        Assert.Single(result);
    }

    [Fact]
    public async Task CreateAuthorAsync_CreatesAndReturnsAuthorDto()
    {
        var authorDto = new AuthorDto { FirstName = "Jane", LastName = "Doe" };
        var author = new Author { Id = 1, FirstName = "Jane", LastName = "Doe" };

        _mockUnitOfWork.Setup(uow => uow.Authors.CreateAuthorAsync(It.IsAny<Author>())).ReturnsAsync(author);
        _mockUnitOfWork.Setup(uow => uow.CompleteAsync()).ReturnsAsync(1);

        var result = await _service.CreateAuthorAsync(authorDto);

        Assert.Equal("Jane", result.FirstName);
        Assert.Equal("Doe", result.LastName);

        _mockUnitOfWork.Verify(uow => uow.Authors.CreateAuthorAsync(It.IsAny<Author>()), Times.Once);
        _mockUnitOfWork.Verify(uow => uow.CompleteAsync(), Times.Once);
    }
}
