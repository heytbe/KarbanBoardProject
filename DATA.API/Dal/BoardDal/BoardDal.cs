using Data.API.Context;
using Data.API.Extensions.ErrorHandler;
using Data.API.Repositories;
using Entity.API.Models.Dto.KarbonDto.CreateDto;
using Entity.API.Models.Dto.KarbonDto.UpdateDto;
using Entity.API.Models.KarbanModels;
using Entity.API.RequestFeature;
using Entity.API.RequestFeature.EntityParameters;
using Microsoft.EntityFrameworkCore;

namespace Data.API.Dal.BoardDal
{
    public class BoardDal : GenericRepository<Board>, IBoardDal
    {
        public BoardDal(AppDbContext context) : base(context)
        {
        }

        public async Task<Board> CreateAsync(BoardCreateDto createDto)
        {
            var board = new Board();

            board.BoardName = createDto.BoardName;
            board.BoardColor = createDto.BoardColor;
            board.UserEmail = createDto.UserEmail;
            if(createDto.BoardListCreateDtos.Count > 0 || createDto.BoardListCreateDtos.Any())
            {
                foreach(var item in  createDto.BoardListCreateDtos)
                {
                    board.BoardLists.Add(new BoardLists()
                    {
                        ListName = item
                    });
                }
            }
            else
            {
                throw new BaseException("Liste alanı boş olamaz.");
            }

            if (createDto.BoardUsersCreateDtos != null)
            {

                if (createDto.BoardUsersCreateDtos.Count > 0 || createDto.BoardUsersCreateDtos.Any())
                {
                    foreach (var item in createDto.BoardUsersCreateDtos)
                    {
                        board.BoardUsers.Add(new BoardUsers()
                        {
                            UserEmail = item
                        });
                    }
                }

            }

            return board;
        }

        public async Task<PagedList<Board>> GetAllAsync(BoardParameters boardParameters, string email, bool trackChanges)
        {
            var board = await GetAll(trackChanges, (x => x.IsDeleted.Equals(false) && x.UserEmail.Equals(email))).ToListAsync();
            return PagedList<Board>.ToPagedList(board,boardParameters.PageNumber,boardParameters.PageSize);
        }

        public async Task<Board> UpdateAsync(Guid id, bool trackChanges, BoardUpdateDto updateDto)
        {
            var board = await GetOne(trackChanges, x => (x.IsDeleted.Equals(false) && x.Id.Equals(id)), a => a.BoardUsers);

            if (board is null)
                throw new BaseException($"{id}'li pano bulunamadı");

            if(board.BoardName != updateDto.BoardName)
            {
                board.BoardName = updateDto.BoardName;
            }

            if (board.BoardColor != updateDto.BoardColor)
            {
                board.BoardColor = updateDto.BoardColor;
            }

            return board;
        }
    }
}