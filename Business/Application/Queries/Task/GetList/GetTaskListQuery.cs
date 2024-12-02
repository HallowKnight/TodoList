using MediatR;

namespace Business.Application.Queries.Task.GetList;

public class GetTaskListQuery : IRequest<List<Domain.Aggregates.TaskAggregate.Task>>;