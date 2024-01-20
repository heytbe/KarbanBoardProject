using AutoMapper;
using Core.API.Response;
using Data.API.Dal.BoardDal;
using Data.API.UnitOfWork;
using Entity.API.Models.Dto.KarbonDto.CreateDto;
using Entity.API.Models.Dto.KarbonDto.ListDto;
using Entity.API.Models.Dto.KarbonDto.UpdateDto;
using Entity.API.Models.KarbanModels;
using Entity.API.RequestFeature;
using Entity.API.RequestFeature.EntityParameters;
using Microsoft.EntityFrameworkCore;
using Service.API.Service.Abstract;

namespace Service.API.Service.Concrate
{
    public class BoardService : IBoardService
    {
        private readonly IBoardDal _board;
        private readonly IBoardUserDal _user;
        private readonly IMapper _mapper;
        private readonly IUnitOfWorkRepo _unitOfWork;

        public BoardService(IBoardDal board, IMapper mapper, IUnitOfWorkRepo unitOfWork, IBoardUserDal user)
        {
            _board = board;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _user = user;
        }

        public async Task<ResponseDto<Response>> CreateAsync(BoardCreateDto createDto)
        {
            var result = await _board.CreateAsync(createDto);
            await _board.AddAsync(result);
            await _unitOfWork.SaveAsync();

            return ResponseDto<Response>.Success("Pano Eklendi", 201);
        }

        public async Task<ResponseDto<Response>> DeleteAsync(bool trackChanges,Guid id)
        {
            var result = await _board.GetOne(trackChanges, x => (x.IsDeleted.Equals(false) && x.Id.Equals(id)));
            if (result is null)
                return ResponseDto<Response>.Fail($"{id} li Board Bulunamadı", 404,true);
            _board.Remove(result);
            await _unitOfWork.SaveAsync();
            return ResponseDto<Response>.Success("Silindi", 200);
        }

        public async Task<(ResponseDto<IEnumerable<BoardListDto>> responseDto, MetaData metaData)> GetAllListAsync(bool trackChanges,string email,BoardParameters boardParameters)
        {
            var result = await _board.GetAllAsync(boardParameters,email,trackChanges);
            if(result is null)
            {
               return (ResponseDto<IEnumerable<BoardListDto>>.Fail("Pano Bulunamadı",404,true), result.MetaData);
            }
            var mapper = _mapper.Map<IEnumerable<BoardListDto>>(result);
            var count = await _board.CountAsync(x => x.IsDeleted.Equals(false));

            return (ResponseDto<IEnumerable<BoardListDto>>.Success(mapper, 200, new Response(count)), result.MetaData);
        }

        public async Task<ResponseDto<BoardListDto>> GetOneByIdAsync(bool trackChanges, Guid id)
        {
            var result = await _board.GetOne(trackChanges,x => (x.IsDeleted.Equals(false) && x.Id.Equals(id)));
            if(result is null)
            {
                return ResponseDto<BoardListDto>.Fail("Pano Bulunamadı", 404, true);
            }

            var mapper = _mapper.Map<BoardListDto>(result);
            return ResponseDto<BoardListDto>.Success(mapper, 200);
        }

        public async Task<ResponseDto<Response>> UpdateAsync(bool trackChanges, Guid id, BoardUpdateDto updateDto)
        {
            var result = await _board.UpdateAsync(id, trackChanges, updateDto);
            _board.Update(result);

            if(updateDto.BoardUsersUpdate is not null)
            {
                foreach(var item in updateDto.BoardUsersUpdate)
                {
                    var boardUsers = new BoardUsers();
                    boardUsers.UserEmail = item;
                    boardUsers.BoardId = result.Id;
                    await _user.AddAsync(boardUsers);
                }
            }
            await _unitOfWork.SaveAsync();
            return ResponseDto<Response>.Success($"{result.BoardName} isimli pano güncellendi", 200);
        }
    }
}
