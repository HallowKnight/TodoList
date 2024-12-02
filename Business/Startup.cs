using System.Reflection;
using Business.Actions.Task.Add;
using Business.Actions.Task.Complete;
using Business.Actions.Task.Delete;
using Business.Actions.Task.Get;
using Business.Actions.Task.GetList;
using Business.Application.Commands.Task;
using Business.Application.Commands.Task.Add;
using Domain.Aggregates.TaskAggregate;
using Domain.Aggregates.TaskAggregate.Exceptions;
using Infrastructure.Repository.Task;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Business;

public class Startup(IConfiguration configuration)
{
    public IConfiguration ConfigRoot { get; } = configuration;

    public void ConfigureServices(IServiceCollection services)
    {
        #region Repository

        services.AddScoped<ITaskCommandRepository, TaskCommandRepository>();
        services.AddScoped<ITaskQueryRepository, TaskQueryRepository>();

        #endregion

        #region Services

        // services.AddTransient<ITaskValidations, TaskValidations>();
        services.AddMediatR(typeof(AddTaskCommand).GetTypeInfo().Assembly);
        services.AddMediatR(Assembly.GetExecutingAssembly());
        services.AddTransient<IAddTaskService, AddTaskService>();
        services.AddTransient<ICompleteTaskService, CompleteTaskService>();
        services.AddTransient<IDeleteTaskService, DeleteTaskService>();
        services.AddTransient<IGetTaskService, GetTaskService>();
        services.AddTransient<IGetTaskListService, GetTaskListService>();
        
        #endregion

    }
}