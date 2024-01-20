using AutoMapper;
using Entity.API.Models.Dto.User;
using Entity.API.Models.Identity;

namespace Services.API.AutoMapper.UserMap
{
    public class UserMapper:Profile
    {
        public UserMapper()
        {
            CreateMap<UserAppDto,AppUser>().ReverseMap();
        }
    }
}
