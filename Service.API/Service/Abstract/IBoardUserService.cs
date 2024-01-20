using Core.API.Response;
using Entity.API.Models.Dto.KarbonDto.ListDto;

namespace Service.API.Service.Abstract
{
    public interface IBoardUserService
    {
        Task<ResponseDto<IEnumerable<BoardUserListDto>>> BoardUserListAsync(bool trackChanges, string email);
    }
}
