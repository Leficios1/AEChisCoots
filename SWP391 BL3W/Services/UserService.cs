using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SWP391_BL3W.Database;
using SWP391_BL3W.DTO.Request;
using SWP391_BL3W.DTO.Response;
using SWP391_BL3W.Repository.Interface;
using SWP391_BL3W.Services.Interface;
using System.Net;

namespace SWP391_BL3W.Services
{
    public class UserService : IUserService
    {
        private readonly IBaseRepository<User> _baseRepository;
        private readonly IMapper _mapper;

        public UserService(IBaseRepository<User> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }
        public async Task<StatusResponse<UserResponseDto>> CreateUser(CreateUserDTO user)
        {
            try
            {
                var response = new StatusResponse<UserResponseDto>();
                if (await CheckEmailExist(user.Email) || await CheckPhoneExist(user.phone))
                {
                    response.statusCode = HttpStatusCode.BadRequest;
                    response.Errormessge = "Email or Phone existed.";
                    return response;
                }
                var createUser = _mapper.Map<User>(user);
                createUser.AvatarUrl = "https://inkythuatso.com/uploads/thumbnails/800/2023/03/9-anh-dai-dien-trang-inkythuatso-03-15-27-03.jpg";
                await _baseRepository.AddAsync(createUser);
                await _baseRepository.SaveChangesAsync();
                var result = await _baseRepository.Get().OrderBy(x => x.Id).Include(x => x.Role).LastAsync();
                var returned = _mapper.Map<UserResponseDto>(result);
                response.Data = returned;
                response.statusCode = HttpStatusCode.OK;
                response.Errormessge = "Successful";
                return response;
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private async Task<bool> CheckEmailExist(string email)
        {
            var result = await _baseRepository.FindOne(x => x.Email.ToLower().Trim() == email.Trim().ToLower());
            if (result != null)
            {
                return true;
            }
            else
                return false;
        }

        private async Task<bool> CheckPhoneExist(string phone)
        {
            var result = await _baseRepository.FindOne(x => x.phone.Trim() == phone.Trim());
            if (result != null)
            {
                return true;
            }
            else
                return false;
        }

        public async Task<IActionResult> EditAvater(string link, int userId)
        {
            var user = await _baseRepository.Get().FirstOrDefaultAsync(x => x.Id == userId);
            if (user == null) return new BadRequestObjectResult("Not Found user!");
            user.AvatarUrl = link.Replace("%2F", "/");
            _baseRepository.Update(user);
            await _baseRepository.SaveChangesAsync();
            return new OkObjectResult("Edit sucessfully");
        }

        public async Task<StatusResponse<UserResponseDto>> GetUser(int id)
        {
            var response = new StatusResponse<UserResponseDto>();
            var user = await _baseRepository.GetById(id);
            if (user == null)
            {
                response.statusCode = HttpStatusCode.NotFound;
                response.Errormessge = "Not Found user";
                return response;
            }
            var userResponseDto = _mapper.Map<UserResponseDto>(user);
            response.Data = userResponseDto;
            response.statusCode = HttpStatusCode.OK;
            response.Errormessge = "Succesful";
            return response;
        }

        public async Task<IEnumerable<UserResponseDto>> GetUsers(int? pageNumber, int? pageSize)
        {
            IQueryable<User> query = _baseRepository.Get()
                .Include(x => x.Role)
                .AsNoTracking();
            if (pageNumber.HasValue && pageSize.HasValue)
            {
                if (pageNumber <= 0 || pageSize <= 0)
                {
                    throw new ArgumentException("Invalid page and page size number!");
                }

                query = query.Skip((pageNumber.Value - 1) * pageSize.Value)
                             .Take(pageSize.Value);
            }
            var users = await query.ToListAsync();
            return _mapper.Map<IEnumerable<UserResponseDto>>(users);
        }

        public async Task<StatusResponse<UserResponseDto>> UpdateUser(UpdateUserDTO user)
        {
            var response = new StatusResponse<UserResponseDto>();
            var existedUser = await _baseRepository.GetById(user.Id);
            if (existedUser != null)
            {
                existedUser.DateOfBirth = user.DateOfBirth;
                existedUser.Gender = user.Gender;
                existedUser.Name = user.Name;
                existedUser.phone = user.Phone;
                existedUser.Email = user.Email;
                existedUser.status = user.Status;
                _baseRepository.Update(existedUser);
                await _baseRepository.SaveChangesAsync();
                response.statusCode = HttpStatusCode.OK;
                response.Errormessge = "Update Successful";
                return response;
            }
            else
            {
                response.statusCode = HttpStatusCode.NotFound;
                response.Errormessge = "Not Found user";
                return response;
            }
        }
    }
}
