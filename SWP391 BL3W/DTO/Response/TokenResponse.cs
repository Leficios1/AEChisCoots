namespace SWP391_BL3W.DTO.Response
{
    public class TokenResponse
    {
        public string TokenString { get; set; } = null!;
        public DateTime Expiration { get; set; }
    }
}
