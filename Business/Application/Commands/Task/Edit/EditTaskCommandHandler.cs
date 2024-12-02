using Domain.Aggregates.TaskAggregate;
using MediatR;

namespace Business.Application.Commands.Task.Edit;

public class EditTaskCommandHandler(ITaskCommandRepository taskCommandRepository,
    ITaskQueryRepository taskQueryRepository) : IRequestHandler<EditTaskCommand>
{
    public async System.Threading.Tasks.Task Handle(EditTaskCommand request, CancellationToken cancellationToken)
    {
        Domain.Aggregates.TaskAggregate.Task task = (await taskQueryRepository.GetAsync(request.Id, cancellationToken))!;
        task.Update(request.Title, request.Description, request.DueDate);
        taskCommandRepository.UpdateTask(task);
    }
}