using Core.API.Response;
using Entity.API.Models.Dto.User;
using Entity.API.Models.Identity;

namespace Services.API.Service.Abstract
{
    public interface IUserService
    {
        Task<ResponseDto<UserAppDto>> CreateUser(CreateUserDto createUserDto);
        Task<ResponseDto<UserAppDto>> GetUsers(string username);
        Task<ResponseDto<UserAppDto>> GetUsersByEmail(string email);
    }
}
