using Library.Core.Dtos;
using Library.Core.Interfaces;
using Library.Core.ViewDtos;
using Library.WebAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Library.WebAPI.Tests;

public class AuthorControllerTests
{
    private readonly Mock<IAuthorService> _mockAuthorService;
    private readonly AuthorController _controller;

    public AuthorControllerTests()
    {
        _mockAuthorService = new Mock<IAuthorService>();
        _controller = new AuthorController(_mockAuthorService.Object);
    }

    [Fact]
    public async Task GetAllAuthors_ReturnsOkResult_WithListOfAuthors()
    {
        // Arrange
        var authors = new List<AuthorDto> { new AuthorDto { FirstName = "John", LastName = "Doe" } };
        _mockAuthorService.Setup(service => service.GetAllAuthorsAsync(1, 10)).ReturnsAsync(authors);

        // Act
        var result = await _controller.GetAllAuthors();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnAuthors = Assert.IsType<List<AuthorDto>>(okResult.Value);
        Assert.Single(returnAuthors);
    }

    [Fact]
    public async Task CreateAuthor_ReturnsOkResult_WhenAuthorCreated()
    {
        // Arrange
        var authorDto = new AuthorDto { FirstName = "Jane", LastName = "Smith" };
        _mockAuthorService.Setup(service => service.CreateAuthorAsync(It.IsAny<AuthorDto>())).ReturnsAsync(authorDto);

        // Act
        var result = await _controller.CreateAuthor(new AuthorViewDto { FirstName = "Jane", LastName = "Smith" });

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var createdAuthor = Assert.IsType<AuthorDto>(okResult.Value);
        Assert.Equal("Jane", createdAuthor.FirstName);
    }
}
