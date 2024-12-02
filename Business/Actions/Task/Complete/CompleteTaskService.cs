using Business.Application.Commands.Task.Complete;
using Domain.Aggregates.TaskAggregate;
using Domain.Aggregates.TaskAggregate.Exceptions;
using Domain.Utility.ExceptionHandler;
using MediatR;

namespace Business.Actions.Task.Complete;

public class CompleteTaskService(
    ITaskQueryRepository taskQueryRepository,
    IMediator mediator) : ICompleteTaskService
{
    public async System.Threading.Tasks.Task CompleteAsync(Guid taskId, CancellationToken cancellationToken)
    {
        Domain.Aggregates.TaskAggregate.Task? task = await taskQueryRepository.GetAsync(taskId, cancellationToken);
        ValidateTask(task);
        task!.Complete();
        await mediator.Publish(new CompleteTaskCommand(task!), cancellationToken);
    }

    private static void ValidateTask(Domain.Aggregates.TaskAggregate.Task? task)
    {
        if (task is null)
        {
            throw ExceptionHandler.GetException(CompleteTaskErrors.NotFound);
        }

        if (task.IsCompleted)
        {
            throw ExceptionHandler.GetException(CompleteTaskErrors.AlreadyDone);
        }
    }
    
    public class CompleteTaskErrors : ErrorTypeEnumeration
    {
        public CompleteTaskErrors(int errorCode, string name) : base(errorCode, name)
        {
        }

        public static readonly CompleteTaskErrors NotFound =
            new((int)CompleteTaskErrorEnum.NotFound,
                nameof(CompleteTaskErrorEnum.NotFound));

        public static readonly CompleteTaskErrors AlreadyDone =
            new((int)CompleteTaskErrorEnum.AlreadyDone,
                nameof(CompleteTaskErrorEnum.AlreadyDone));
    }
}