using MediatR;

namespace Business.Application.Commands.Task.Complete;

public class CompleteTaskCommand(Domain.Aggregates.TaskAggregate.Task task) : IRequest
{
    public Domain.Aggregates.TaskAggregate.Task Task { get; } = task;
}