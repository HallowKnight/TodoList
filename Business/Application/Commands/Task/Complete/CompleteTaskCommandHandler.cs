using Domain.Aggregates.TaskAggregate;
using MediatR;

namespace Business.Application.Commands.Task.Complete;

public class CompleteTaskCommandHandler(ITaskCommandRepository taskCommandRepository) : IRequestHandler<CompleteTaskCommand>
{
    public System.Threading.Tasks.Task Handle(CompleteTaskCommand request, CancellationToken cancellationToken)
    {
        taskCommandRepository.UpdateTask(request.Task);
        return System.Threading.Tasks.Task.CompletedTask;
    }
}