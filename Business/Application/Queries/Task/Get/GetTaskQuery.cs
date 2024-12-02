using Business.Actions.Task.Get.Dto;
using MediatR;

namespace Business.Application.Queries.Task.Get;

public class GetTaskQuery(Guid id) : IRequest<Domain.Aggregates.TaskAggregate.Task?>
{
    public Guid Id { get; } = id;
}