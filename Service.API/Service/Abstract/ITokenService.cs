using Entity.API.Models.Dto.Token;
using Entity.API.Models.Identity;

namespace Services.API.Service.Abstract
{
    public interface ITokenService
    {
        TokenDto CreateToken(AppUser userApp);
    }
}
