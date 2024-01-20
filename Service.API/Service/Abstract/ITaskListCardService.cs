using Core.API.Response;
using Entity.API.Models.Dto.KarbonDto.CreateDto;
using Entity.API.Models.Dto.KarbonDto.ListDto;
using Entity.API.Models.Dto.KarbonDto.UpdateDto;

namespace Service.API.Service.Abstract
{
    public interface ITaskListCardService
    {
        Task<ResponseDto<Response>> CreateAsync(TaskListCreateDto createDto,Guid BoardListId);
        Task<ResponseDto<Response>> DeleteAsync(bool trackChanges, Guid id);
        Task<ResponseDto<Response>> UpdateAsync(bool trackChanges,ListCardUpdateDto updateDto ,Guid id);
        Task<ResponseDto<ListCardDto>> GetByIdAsync(bool trakChanges,Guid id);
    }
}
