using Data.API.Repositories;
using Entity.API.Models.Dto.KarbonDto.CreateDto;
using Entity.API.Models.Dto.KarbonDto.UpdateDto;
using Entity.API.Models.KarbanModels;
using Entity.API.RequestFeature;
using Entity.API.RequestFeature.EntityParameters;

namespace Data.API.Dal.BoardDal
{
    public interface IBoardDal : IGenericRepository<Board>
    {
        Task<Board> CreateAsync(BoardCreateDto createDto);
        Task<PagedList<Board>> GetAllAsync(BoardParameters boardParameters, string email, bool trackChanges);
        Task<Board> UpdateAsync(Guid id,bool trackChanges,BoardUpdateDto updateDto);
    }
}
