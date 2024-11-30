namespace Library.Core.ViewDtos
{
    public class AuthoriseViewDto
    {
        public string AccessToken { get; set; } = null!;
        public string RefreshToken { get; set; } = null!;
    }
}
