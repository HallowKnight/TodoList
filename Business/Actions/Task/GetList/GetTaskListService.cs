using Business.Actions.Task.Get.Dto;
using Business.Application.Queries.Task.GetList;
using MediatR;

namespace Business.Actions.Task.GetList;

public class GetTaskListService(IMediator mediator) : IGetTaskListService
{
    public async Task<List<TaskDto>> GetAllAsync(CancellationToken cancellationToken)
    {
        return (await mediator.Send(new GetTaskListQuery(), cancellationToken)).Select(task => new TaskDto(task)).ToList();
    }
}