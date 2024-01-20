using Data.API.Context;
using Data.API.Dal.TaskListDal.Abstract;
using Data.API.Repositories;
using Entity.API.Models.KarbanModels;

namespace Data.API.Dal.TaskListDal.Concrate
{
    public class TaskListDal : GenericRepository<BoardLists>, ITaskListDal
    {
        public TaskListDal(AppDbContext context) : base(context)
        {
        }
    }
}
