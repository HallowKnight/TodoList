using Business.Application.Commands.Task.Complete;
using Domain.Aggregates.TaskAggregate;
using Domain.Aggregates.TaskAggregate.Exceptions;
using Domain.Utility.ExceptionHandler;
using MediatR;

namespace Business.Actions.Task.Complete;

public class CompleteTaskService(IMediator mediator) : ICompleteTaskService
{
    public async System.Threading.Tasks.Task CompleteAsync(Guid taskId, CancellationToken cancellationToken)
    {
        await mediator.Publish(new CompleteTaskCommand(taskId), cancellationToken);
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