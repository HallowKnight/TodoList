using Business.Actions.Task.Edit.Dto;
using Business.Application.Commands.Task.Edit;
using Domain.Aggregates.TaskAggregate.Exceptions;
using Domain.Utility.ExceptionHandler;
using MediatR;

namespace Business.Actions.Task.Edit;

public class EditTaskService(IMediator mediator) : IEditTaskService
{
    public async System.Threading.Tasks.Task EditAsync(EditTaskDto editTaskDto, CancellationToken cancellationToken)
    {
        await mediator.Send(new EditTaskCommand(editTaskDto), cancellationToken);
    }
}