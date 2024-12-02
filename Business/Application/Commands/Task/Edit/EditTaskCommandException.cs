using Domain.Aggregates.TaskAggregate.Exceptions;
using Domain.Utility.ExceptionHandler;
using MediatR;

namespace Business.Application.Commands.Task.Edit;

public class EditTaskCommandException<TRequest>(int errorCode, string name) : ErrorTypeEnumeration(errorCode, name)
    where TRequest : IRequest
{
    public static readonly EditTaskCommandException<TRequest> TitleMaxLengthExceeded =
        new((int)EditTaskErrorEnum.TitleMaxLengthExceeded,
            nameof(EditTaskErrorEnum.TitleMaxLengthExceeded));
    
    public static readonly EditTaskCommandException<TRequest> InvalidDueDate =
        new((int)EditTaskErrorEnum.InvalidDueDate,
            nameof(EditTaskErrorEnum.InvalidDueDate));
    
    public static readonly EditTaskCommandException<TRequest> AlreadyDone =
        new((int)EditTaskErrorEnum.AlreadyDone,
            nameof(EditTaskErrorEnum.AlreadyDone));
    
    public static readonly EditTaskCommandException<TRequest> NotFound =
        new((int)EditTaskErrorEnum.NotFound,
            nameof(EditTaskErrorEnum.NotFound));
}