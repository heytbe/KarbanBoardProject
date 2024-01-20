using Data.API.Context;
using Data.API.Dal.TaskListDal.Abstract;
using Data.API.Repositories;
using Entity.API.Models.KarbanModels;

namespace Data.API.Dal.TaskListDal.Concrate
{
    public class TaskCardAdditionDal : GenericRepository<ListAddition>, ITaskCardAdditionDal
    {
        public TaskCardAdditionDal(AppDbContext context) : base(context)
        {
        }
    }
}
