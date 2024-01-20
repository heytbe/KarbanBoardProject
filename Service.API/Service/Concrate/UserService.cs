using AutoMapper;
using Core.API.Response;
using Data.API.Extensions.Upload;
using Entity.API.Models.Dto.User;
using Entity.API.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Services.API.Service.Abstract;

namespace Services.API.Service.Cocrate
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _manager;
        private readonly IMapper _mapper;
        public UserService(UserManager<AppUser> manager,IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public async Task<ResponseDto<UserAppDto>> CreateUser(CreateUserDto createUserDto)
        {
            var image = await UploadExtensions.UploadExtension(createUserDto.Photo);
            var user = new AppUser
            {
                UserName = createUserDto.UserName,
                Email = createUserDto.Email,
                UserPhoto = image.Path
            };

            var response = await _manager.CreateAsync(user, createUserDto.Password);
            if(response.Succeeded)
            {
                return ResponseDto<UserAppDto>.Success("Kayıt Edildi",200);
            }
            else
            {
                var error = response.Errors.Select(x => x.Description).ToList();
                return ResponseDto<UserAppDto>.Fail(new ErrorDto(error, true), 400);
            }
        }

        public async Task<ResponseDto<UserAppDto>> GetUsers(string userName)
        {
            var user = await _manager.FindByNameAsync(userName);
            if (user is null)
            {
                return ResponseDto<UserAppDto>.Fail("Bulunamadı",404,true);
            }

            var mapper = _mapper.Map<UserAppDto>(user);

            return ResponseDto<UserAppDto>.Success(mapper,200);
        }

        public async Task<ResponseDto<UserAppDto>> GetUsersByEmail(string email)
        {
            var user = await _manager.FindByEmailAsync(email);
            if (user is null)
            {
                return ResponseDto<UserAppDto>.Fail("Bulunamadı", 404, true);
            }

            var mapper = _mapper.Map<UserAppDto>(user);

            return ResponseDto<UserAppDto>.Success(mapper, 200);
        }
    }
}
