using Business.Actions.Task.Add;
using Domain.Aggregates.TaskAggregate;
using Infrastructure.Repository.Task;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Business;

public static class StartUp
{
    public static void ConfigureBusinessServices(this IServiceCollection services, IConfiguration configuration)
    {
        #region Repository

        services.AddScoped<ITaskCommandRepository, TaskCommandRepository>();
        services.AddScoped<ITaskQueryRepository, TaskQueryRepository>();

        #endregion

        #region Services

        services.AddTransient<IAddTaskService, AddTaskService>();
        
        #endregion

    }
}