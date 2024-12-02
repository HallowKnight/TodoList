using Business.Actions.Task.Get.Dto;
using Business.Application.Queries.Task.Get;
using Domain.Utility.ExceptionHandler;
using MediatR;

namespace Business.Actions.Task.Get;

public class GetTaskService(IMediator mediator) : IGetTaskService
{
    public async Task<TaskDto> GetAsync(Guid taskId, CancellationToken cancellationToken)
    {
        Domain.Aggregates.TaskAggregate.Task? task = await mediator.Send(new GetTaskQuery(taskId), cancellationToken);
        if (task == null)
        {
            throw ExceptionHandler.GetException(ErrorTypeEnumeration.NotFound);
        }
        return new TaskDto(task);
    }
}