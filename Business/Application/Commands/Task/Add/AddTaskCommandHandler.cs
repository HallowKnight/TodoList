using Domain.Aggregates.TaskAggregate;
using MediatR;

namespace Business.Actions.Task.Add;

public class AddTaskCommandHandler(ITaskCommandRepository taskCommandRepository) : IRequestHandler<AddTaskCommand>
{
    public async System.Threading.Tasks.Task Handle(AddTaskCommand request, CancellationToken cancellationToken)
    {
        await taskCommandRepository.AddTaskAsync(
            new Domain.Aggregates.TaskAggregate.Task(request.Title, request.Description, request.DueDate),
            cancellationToken);
    }
}