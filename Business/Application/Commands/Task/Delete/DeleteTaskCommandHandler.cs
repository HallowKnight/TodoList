using Domain.Aggregates.TaskAggregate;
using MediatR;

namespace Business.Application.Commands.Task.Delete;

public class DeleteTaskCommandHandler(ITaskCommandRepository taskCommandRepository,
    ITaskQueryRepository taskQueryRepository) : IRequestHandler<DeleteTaskCommand>
{
    public async System.Threading.Tasks.Task Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
    {
        taskCommandRepository.Delete((await taskQueryRepository.GetAsync(request.Id, cancellationToken))!);
    }
}