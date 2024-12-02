using Domain.Aggregates.TaskAggregate.Exceptions;
using Domain.Utility.ExceptionHandler;
using MediatR;

namespace Business.Application.Commands.Task.Delete;

public class DeleteTaskCommandException<TRequest>(int errorCode, string name) : ErrorTypeEnumeration(errorCode, name)
    where TRequest : IRequest
{
    public static readonly DeleteTaskCommandException<TRequest> NotFound =
        new((int)DeleteTaskErrorEnum.NotFound,
            nameof(DeleteTaskErrorEnum.NotFound));
}