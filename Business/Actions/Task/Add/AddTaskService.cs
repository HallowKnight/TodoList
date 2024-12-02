using Business.Actions.Task.Add.Dto;
using Business.Application.Commands.Task.Add;
using Domain.Aggregates.TaskAggregate.Exceptions;
using Domain.Utility.ExceptionHandler;
using MediatR;

namespace Business.Actions.Task.Add;

public class AddTaskService(IMediator mediator) : IAddTaskService
{
    public async System.Threading.Tasks.Task AddAsync(AddTaskDto addTaskDto, CancellationToken cancellationToken = default)
    {
        await mediator.Publish(new AddTaskCommand(addTaskDto), cancellationToken);
    }
}