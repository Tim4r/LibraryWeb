﻿namespace Library.Core.Dtos;

public class BookDto
{
    public string Title { get; set; } = string.Empty;
    public string ISBN { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string? Image { get; set; } = string.Empty;
    public int AuthorId { get; set; }
    public int CategoryId { get; set; }
}
