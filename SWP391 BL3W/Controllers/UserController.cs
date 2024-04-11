using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SWP391_BL3W.DTO.Request;
using SWP391_BL3W.DTO.Response;
using SWP391_BL3W.Services.Interface;

namespace SWP391_BL3W.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet("user/getById")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _userService.GetUser(id);
            return StatusCode((int)response.statusCode, new { data = response.Data, message = response.Errormessge });
        }

        [HttpGet("user/getUser")]
        public async Task<ActionResult<IEnumerable<UserResponseDto>>> GetUsers(int? pageNumber, int? pageSize)
        {
            var users = await _userService.GetUsers(pageNumber, pageSize);
            return Ok(users);
        }

        [HttpPost("user/create")]
        public async Task<IActionResult> createUser([FromBody] CreateUserDTO DTO)
        {
            var response = await _userService.CreateUser(DTO);
            return StatusCode((int)response.statusCode, new { data = response.Data, message = response.Errormessge });
        }

        [HttpPut("user/update")]
        public async Task<IActionResult> updateUser(UpdateUserDTO DTO)
        {
            var response = await _userService.UpdateUser(DTO);
            return StatusCode((int)response.statusCode, new { data = response.Data, message = response.Errormessge });
        }

        [HttpPut("users/change-avatar/{id}")]
        public async Task<IActionResult> EditAvatar([FromRoute] int id, [FromBody] string link)
        {

            var result = await _userService.EditAvater(link, id);

            return result;
        }
    }
}
