using Domain.Aggregates.TaskAggregate;
using MediatR;

namespace Business.Application.Commands.Task.Complete;

public class CompleteTaskCommandHandler(ITaskCommandRepository taskCommandRepository,
    ITaskQueryRepository taskQueryRepository) : IRequestHandler<CompleteTaskCommand>
{
    public async System.Threading.Tasks.Task Handle(CompleteTaskCommand request, CancellationToken cancellationToken)
    {
        Domain.Aggregates.TaskAggregate.Task task = (await taskQueryRepository.GetAsync(request.Id, cancellationToken))!;
        task.Complete();
        taskCommandRepository.UpdateTask(task);
    }
}