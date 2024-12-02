using Business.Application.Commands.Task.Delete;
using MediatR;

namespace Business.Actions.Task.Delete;

public class DeleteTaskService(IMediator mediator) : IDeleteTaskService
{
    public async System.Threading.Tasks.Task DeleteAsync(Guid taskId, CancellationToken cancellationToken)
    {
        await mediator.Publish(new DeleteTaskCommand(taskId), cancellationToken);
    }
}