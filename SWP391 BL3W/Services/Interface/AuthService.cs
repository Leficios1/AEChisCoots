using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SWP391_BL3W.Database;
using SWP391_BL3W.DTO.Response;
using SWP391_BL3W.Repository.Interface;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SWP391_BL3W.Services.Interface
{
    public class AuthService : IAuthService
    {
        private readonly IBaseRepository<User> _userRepo;
        private readonly IConfiguration _configuration;
        public AuthService(IBaseRepository<User> userRepo, IConfiguration configuration)
        {
            _userRepo = userRepo;
            _configuration = configuration;
        }

        public async Task<TokenResponse> LoginAccount(string email, string password)
        {
            try
            {
                var checkUser = await _userRepo.Get().Include(x => x.Role).Where(x => x.Password == password && x.Email.ToLower().Trim() == email.ToLower().Trim()).FirstOrDefaultAsync();

                if (checkUser == null)
                {
                    throw new UnauthorizedAccessException("The email/password is wrong.");
                }
                else
                {
                    JwtSecurityToken token = GetToken(checkUser);

                    var returnedToken = new TokenResponse()
                    {
                        TokenString = new JwtSecurityTokenHandler().WriteToken(token),
                        Expiration = token.ValidTo
                    };
                    return returnedToken;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex}");

            }
        }

        public JwtSecurityToken GetToken(User user)
        {
            List<Claim> authClaims = new List<Claim>
            {
                 new Claim(ClaimTypes.Name, user.Name),
                 new Claim(ClaimTypes.Email, user.Email),
                 new Claim(ClaimTypes.Role, user.RoleId.ToString()),
                 new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };

            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(

                issuer: _configuration["JWT:ValidAudience"],
                audience: _configuration["JWT:ValidIssuer"],
                claims: authClaims,
                expires: DateTime.Now.AddDays(3),
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );

            return token;
        }

        public ClaimsPrincipal DecodeToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["JWT:Secret"]);

            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = "http://localhost:5028",
                    ValidAudience = "http://localhost:5028",
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var claimsIdentity = new ClaimsIdentity(jwtToken.Claims);

                return new ClaimsPrincipal(claimsIdentity);
            }
            catch (Exception ex)
            {
                // Xử lý trường hợp token không hợp lệ
                Console.WriteLine($"Token validation failed: {ex.Message}");
                return null;
            }
        }
        public async Task<UserByTokenResponse> GetUserByToken(string token)
        {
            var principals = DecodeToken(token);
            if (principals == null) throw new BadHttpRequestException("The token is invalid");

            var idClaim = principals.FindFirst(ClaimTypes.NameIdentifier);
            if (idClaim == null) throw new Exception("Token is invalid. There is no indentity of name");

            var id = idClaim.Value;
            var user = await _userRepo.Get().Select(x => new UserByTokenResponse()
            {
                Id = x.Id,
                Name = x.Name,
                status = x.status,
                DateOfBirth = x.DateOfBirth,
                AvatarUrl = x.AvatarUrl,
                Gender = x.Gender,
                Email = x.Email,
                Address = x.Address,
                phone = x.phone,
                RoleId = x.RoleId,

            }).FirstOrDefaultAsync(x => x.Id.ToString().Equals(id));

            if (user == null) throw new Exception("There is no user has by id:");

            return user;

        }
        private long ToUnixEpochDate(DateTime date)
        {
            return (long)Math.Round((date.ToUniversalTime() - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds);
        }
    }
}

