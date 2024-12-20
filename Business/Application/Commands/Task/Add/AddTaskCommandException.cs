using Domain.Aggregates.TaskAggregate.Exceptions;
using Domain.Aggregates.TaskAggregate.Exceptions.ErrorEnums;
using Domain.Utility.ExceptionHandler;
using MediatR;

namespace Business.Application.Commands.Task.Add;

public class AddTaskCommandException<TRequest>(int errorCode, string name) : ErrorTypeEnumeration(errorCode, name)
    where TRequest : IRequest
{
    public static readonly AddTaskCommandException<TRequest> TitleRequired =
        new((int)AddTaskErrorEnum.TitleRequired,
            nameof(AddTaskErrorEnum.TitleRequired));
    
    public static readonly AddTaskCommandException<TRequest> TitleMaxLengthExceeded =
        new((int)AddTaskErrorEnum.TitleMaxLengthExceeded,
            nameof(AddTaskErrorEnum.TitleMaxLengthExceeded));

    public static readonly AddTaskCommandException<TRequest> DescriptionRequired =
        new((int)AddTaskErrorEnum.DescriptionRequired,
            nameof(AddTaskErrorEnum.DescriptionRequired));

    public static readonly AddTaskCommandException<TRequest> DueDateRequired =
        new((int)AddTaskErrorEnum.DueDateRequired,
            nameof(AddTaskErrorEnum.DueDateRequired));

    public static readonly AddTaskCommandException<TRequest> InvalidDueDate =
        new((int)AddTaskErrorEnum.InvalidDueDate,
            nameof(AddTaskErrorEnum.InvalidDueDate));
}