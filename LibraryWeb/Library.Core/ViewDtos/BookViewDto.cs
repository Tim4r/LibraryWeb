﻿namespace Library.Core.ViewDto;

public class BookViewDto
{
    public string Title { get; set; } = string.Empty;
    public string ISBN { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string? Image { get; set; } = string.Empty;
    public int AuthorId { get; set; }
    public int GenreId { get; set; }
}
