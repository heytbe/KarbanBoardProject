using Data.API.Context;
using Data.API.Repositories;
using Entity.API.Models.KarbanModels;

namespace Data.API.Dal.BoardDal
{
    public class BoardUserDal : GenericRepository<BoardUsers>, IBoardUserDal
    {
        public BoardUserDal(AppDbContext context) : base(context)
        {
        }
    }
}
