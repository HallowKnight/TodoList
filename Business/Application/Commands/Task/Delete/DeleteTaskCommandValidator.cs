using Domain.Aggregates.TaskAggregate.Exceptions;
using Domain.Utility.ExceptionHandler;
using FluentValidation;

namespace Business.Application.Commands.Task.Delete;

public class DeleteTaskCommandValidator : AbstractValidator<DeleteTaskCommand>
{
    public DeleteTaskCommandValidator()
    {
        // RuleFor(task => task.Id)
        //     .MustAsync(async (taskId, cancellationToken) =>
        //         await taskValidations.TaskExistAsync(taskId, cancellationToken))
        //     .WithErrorCode(ErrorTypeEnumeration.NotFound.Name);
    }
}