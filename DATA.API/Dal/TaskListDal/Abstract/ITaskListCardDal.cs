using Data.API.Repositories;
using Entity.API.Models.Dto.KarbonDto.CreateDto;
using Entity.API.Models.Dto.KarbonDto.UpdateDto;
using Entity.API.Models.KarbanModels;

namespace Data.API.Dal.TaskListDal.Abstract
{
    public interface ITaskListCardDal : IGenericRepository<ListCard>
    {
        Task<ListCard> CreateAsync(TaskListCreateDto createDto,Guid BoardId);
        Task<ListCard> UpdateAsync(bool trackChanges, ListCardUpdateDto updateDto, Guid id);
    }
}
