using Microsoft.AspNetCore.Mvc;
using SWP391_BL3W.DTO.Request;
using SWP391_BL3W.DTO.Response;

namespace SWP391_BL3W.Services.Interface
{
    public interface IUserService
    {
        Task<IActionResult> EditAvater(string link, int userId);
        Task<StatusResponse<UserResponseDto>> CreateUser(CreateUserDTO user);

        Task<IEnumerable<UserResponseDto>> GetUsers(int? pageNumber, int? pageSize);

        Task<StatusResponse<UserResponseDto>> GetUser(int id);

        Task<StatusResponse<UserResponseDto>> UpdateUser(UpdateUserDTO user);
    }
}
