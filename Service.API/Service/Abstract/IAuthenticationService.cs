using Core.API.Response;
using Entity.API.Models.Dto.Token;
using Entity.API.Models.Dto.User;

namespace Services.API.Service.Abstract
{
    public interface IAuthenticationService
    {
        Task<ResponseDto<TokenDto>> CreateToken(LoginDto loginDto);
    }
}
