namespace AuthDemo.Models.DTOs
{
    public class TokenResponse
    {
        public string Token { get; set; } = null!;
        public string RefreshToken { get; set; } = null!;
    }
}
