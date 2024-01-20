using Core.API.Response;
using Entity.API.Models.Dto.KarbonDto.ListDto;

namespace Service.API.Service.Abstract
{
    public interface ITaskListService
    {
        Task<ResponseDto<IEnumerable<BoardListsListDto>>> GetAllTaskListByBoardAsync(bool trackChanges, Guid id);
    }
}
