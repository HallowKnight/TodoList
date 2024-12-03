using System.Reflection;
using Business.Actions.Task.Add;
using Business.Actions.Task.Complete;
using Business.Actions.Task.Delete;
using Business.Actions.Task.Edit;
using Business.Actions.Task.Get;
using Business.Actions.Task.GetList;
using Business.Application.Behaviors;
using Business.Application.Commands.Task.Add;
using Domain.Aggregates.TaskAggregate;
using FluentValidation;
using Infrastructure.Persistence.DbContext;
using Infrastructure.Repository.Task;
using MediatR;
using MediatR.Pipeline;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Business;

public class Startup(IConfiguration configuration)
{
    public IConfiguration ConfigRoot { get; } = configuration;

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<SqlDbContext>(option =>
            option.UseSqlServer(configuration.GetConnectionString("SqlDbContext")));
        
        #region Repository

        services.AddScoped<ITaskCommandRepository, TaskCommandRepository>();
        services.AddScoped<ITaskQueryRepository, TaskQueryRepository>();

        #endregion

        #region Services
        
        services.AddTransient<IAddTaskService, AddTaskService>();
        services.AddTransient<ICompleteTaskService, CompleteTaskService>();
        services.AddTransient<IDeleteTaskService, DeleteTaskService>();
        services.AddTransient<IEditTaskService, EditTaskService>();
        services.AddTransient<IGetTaskService, GetTaskService>();
        services.AddTransient<IGetTaskListService, GetTaskListService>();
        
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(typeof(Startup).Assembly);
        });
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Startup).Assembly));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidatorBehavior<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(TransactionBehavior<,>));
        services.AddValidatorsFromAssemblyContaining<AddTaskCommandValidator>();
        #endregion
    }
}