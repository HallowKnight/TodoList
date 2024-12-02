using Business.Actions.Task;
using Business.Actions.Task.Add;
using Business.Actions.Task.Complete;
using Business.Application.Commands.Task;
using Domain.Aggregates.TaskAggregate;
using Domain.Aggregates.TaskAggregate.Exceptions;
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

        services.AddTransient<ITaskValidations, TaskValidations>();
        services.AddTransient<IAddTaskService, AddTaskService>();
        services.AddTransient<ICompleteTaskService, CompleteTaskService>();
        
        #endregion

    }
}