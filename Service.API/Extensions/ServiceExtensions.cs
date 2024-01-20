using Microsoft.Extensions.DependencyInjection;
using Service.API.Service.Abstract;
using Service.API.Service.Concrate;
using Services.API.Service.Abstract;
using Services.API.Service.Cocrate;
using System.Reflection;

namespace Service.API.Extensions
{
    public static class ServiceExtensions
    {
        public static void ServiceLoadExtensions(this IServiceCollection services)
        {
            var mapper = Assembly.GetExecutingAssembly();

            services.AddAutoMapper(mapper);
            services.AddScoped<IBoardService,BoardService>();
            services.AddScoped<ITaskListService,TaskListService>();
            services.AddScoped<ITaskListCardService, TaskListCardService>();
            services.AddScoped<ITicketService,TicketService>();
            services.AddScoped<IAdditionService,AdditionService>();
            services.AddScoped<IAuthenticationService,AuthenticationService>();
            services.AddScoped<ITokenService,TokenService>();
            services.AddScoped<IUserService,UserService>();
            services.AddScoped<IBoardUserService,BoardUserService>();
        }
    }
}
