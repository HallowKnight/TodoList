using MediatR;

namespace Business.Application.Commands.Task.Delete;

public class DeleteTaskCommand(Guid taskId) : IRequest
{
    public Guid Id { get; } = taskId;
}