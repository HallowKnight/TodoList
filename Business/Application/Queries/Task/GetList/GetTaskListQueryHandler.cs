using Business.Application.Queries.Task.Get;
using Domain.Aggregates.TaskAggregate;
using MediatR;

namespace Business.Application.Queries.Task.GetList;

public class GetTaskListQueryHandler(ITaskQueryRepository taskQueryRepository) : IRequestHandler<GetTaskListQuery, List<Domain.Aggregates.TaskAggregate.Task>>
{
    public async Task<List<Domain.Aggregates.TaskAggregate.Task>> Handle(GetTaskListQuery request, CancellationToken cancellationToken)
    {
        return await taskQueryRepository.GetListAsync(cancellationToken);
    }
}