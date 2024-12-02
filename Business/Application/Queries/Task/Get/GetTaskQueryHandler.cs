using Business.Actions.Task.Get.Dto;
using Domain.Aggregates.TaskAggregate;
using MediatR;

namespace Business.Application.Queries.Task.Get;

public class GetTaskQueryHandler(ITaskQueryRepository taskQueryRepository) : IRequestHandler<GetTaskQuery, Domain.Aggregates.TaskAggregate.Task?>
{
    public async Task<Domain.Aggregates.TaskAggregate.Task?> Handle(GetTaskQuery request, CancellationToken cancellationToken)
    {
        return await taskQueryRepository.GetAsync(request.Id, cancellationToken);
    }
}