using MediatR;

namespace Business.Application.Commands.Task.Complete;

public class CompleteTaskCommand(Guid id) : IRequest
{
    public Guid Id { get; } = id;
}