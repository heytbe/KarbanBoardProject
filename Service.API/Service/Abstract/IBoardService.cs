using Core.API.Response;
using Entity.API.Models.Dto.KarbonDto.CreateDto;
using Entity.API.Models.Dto.KarbonDto.ListDto;
using Entity.API.Models.Dto.KarbonDto.UpdateDto;
using Entity.API.RequestFeature;
using Entity.API.RequestFeature.EntityParameters;

namespace Service.API.Service.Abstract
{
    public interface IBoardService
    {
        Task<ResponseDto<Response>> CreateAsync(BoardCreateDto createDto);
        Task<ResponseDto<Response>> DeleteAsync(bool trackChanges,Guid id);
        Task<(ResponseDto<IEnumerable<BoardListDto>> responseDto, MetaData metaData)> GetAllListAsync(bool trackChanges,string email, BoardParameters boardParameters);
        Task<ResponseDto<Response>> UpdateAsync(bool trackChanges,Guid id,BoardUpdateDto updateDto);
        Task<ResponseDto<BoardListDto>> GetOneByIdAsync(bool trackChanges, Guid id);
    }
}
