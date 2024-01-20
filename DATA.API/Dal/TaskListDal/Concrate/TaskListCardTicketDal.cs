using Data.API.Context;
using Data.API.Dal.TaskListDal.Abstract;
using Data.API.Repositories;
using Entity.API.Models.KarbanModels;

namespace Data.API.Dal.TaskListDal.Concrate
{
    public class TaskListCardTicketDal : GenericRepository<ListTicket>, ITaskListCardTicketDal
    {
        public TaskListCardTicketDal(AppDbContext context) : base(context)
        {
        }
    }
}
