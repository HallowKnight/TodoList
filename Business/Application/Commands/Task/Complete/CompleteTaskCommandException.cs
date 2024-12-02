using Domain.Aggregates.TaskAggregate.Exceptions;
using Domain.Utility.ExceptionHandler;
using MediatR;

namespace Business.Application.Commands.Task.Edit;

public class CompleteTaskCommandException<TRequest>(int errorCode, string name) : ErrorTypeEnumeration(errorCode, name)
    where TRequest : IRequest
{
    public static readonly CompleteTaskCommandException<TRequest> AlreadyDone =
        new((int)EditTaskErrorEnum.AlreadyDone,
            nameof(EditTaskErrorEnum.AlreadyDone));
    
    public static readonly CompleteTaskCommandException<TRequest> NotFound =
        new((int)EditTaskErrorEnum.NotFound,
            nameof(EditTaskErrorEnum.NotFound));
}