using CleanArchitHomework.Application.Services;
using CleanArchitHomework.Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using CleanArchitHomework.Domain.Interfaces;
using CleanArchitHomework.Infrastructure.Data.Repository;

namespace CleanArchitHomework.Infrastructure.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<ITasksService, TasksService>();
            services.AddScoped<ITasksRepository, TaskRepository>();
        }
    }
}