using Data.API.Context;
using Data.API.Dal.BoardDal;
using Data.API.Dal.TaskListDal.Abstract;
using Data.API.Dal.TaskListDal.Concrate;
using Data.API.Repositories;
using Data.API.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Data.API.Extensions
{
    public static class DataExtensions
    {
        public static void DataLoadExtensions(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(x =>
            {
                x.UseSqlServer(configuration["ConnectionStrings:Mssql"]);

            });

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IBoardDal, BoardDal>();
            services.AddScoped<IBoardUserDal, BoardUserDal>();
            services.AddScoped<ITaskListDal, TaskListDal>();
            services.AddScoped<ITaskListCardDal, TaskListCardDal>();
            services.AddScoped<ITaskCardAdditionDal, TaskCardAdditionDal>();
            services.AddScoped<ITaskListCardTicketDal, TaskListCardTicketDal>();
            services.AddScoped<IUnitOfWorkRepo, UnitOfWorkRepo>();
        
        }

    }
}
