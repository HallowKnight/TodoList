using Domain.Aggregates.TaskAggregate.Exceptions;
using Domain.Utility.ExceptionHandler;
using FluentValidation;

namespace Business.Application.Commands.Task.Complete;

public class CompleteTaskCommandValidator : AbstractValidator<CompleteTaskCommand>
{
    public CompleteTaskCommandValidator()
    {
        // RuleFor(command => command.Id)
        //     .MustAsync(async (taskId, cancellationToken) =>
        //         await taskValidations.TaskExistAsync(taskId, cancellationToken))
        //     .WithErrorCode(ErrorTypeEnumeration.NotFound.Name);
        //
        // RuleFor(command => command.Id)
        //     .MustAsync(async (taskId, cancellationToken) =>
        //         !await taskValidations.TaskAlreadyCompleted(taskId, cancellationToken))
        //     .WithErrorCode(CompleteTaskCommandException<CompleteTaskCommand>.AlreadyDone.Name);
    }
}