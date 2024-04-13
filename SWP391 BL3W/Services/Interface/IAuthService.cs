using SWP391_BL3W.DTO.Response;

namespace SWP391_BL3W.Services.Interface
{
    public interface IAuthService
    {
        public Task<TokenResponse> LoginAccount(string email, string passwod);
        public Task<UserByTokenResponse> GetUserByToken(string token);
    }
}
