using AutoMapper;
using Core.API.Response;
using Data.API.Dal.BoardDal;
using Entity.API.Models.Dto.KarbonDto.ListDto;
using Microsoft.EntityFrameworkCore;
using Service.API.Service.Abstract;

namespace Service.API.Service.Concrate
{
    public class BoardUserService : IBoardUserService
    {
        private readonly IBoardUserDal _boardUserDal;
        private readonly IMapper _mapper;

        public BoardUserService(IBoardUserDal boardUserDal, IMapper mapper)
        {
            _boardUserDal = boardUserDal;
            _mapper = mapper;
        }

        public async Task<ResponseDto<IEnumerable<BoardUserListDto>>> BoardUserListAsync(bool trackChanges, string email)
        {
            var result = await _boardUserDal.GetAll(trackChanges, x => (x.IsDeleted.Equals(false) && x.UserEmail.Equals(email)),x => x.Board).ToListAsync();
            if(result is null)
            {
                return ResponseDto<IEnumerable<BoardUserListDto>>.Fail("Bulunumadı", 404, true);
            }

            var mapper = _mapper.Map<IEnumerable<BoardUserListDto>>(result);

            return ResponseDto<IEnumerable<BoardUserListDto>>.Success(mapper, 200);
        }
    }
}
