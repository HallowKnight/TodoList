using Business.Application.Commands.Task.Complete;
using Domain.Aggregates.TaskAggregate.Exceptions;
using FluentValidation;

namespace Business.Application.Commands.Task.Edit;

public class CompleteTaskCommandValidator : AbstractValidator<CompleteTaskCommand>
{
    public CompleteTaskCommandValidator(ITaskValidations taskValidations)
    {
        RuleFor(command => command.Id)
            .MustAsync(async (taskId, cancellationToken) =>
                await taskValidations.TaskExistAsync(taskId, cancellationToken))
            .WithErrorCode(CompleteTaskCommandException<CompleteTaskCommand>.AlreadyDone.Name);

        RuleFor(command => command.Id)
            .MustAsync(async (taskId, cancellationToken) =>
                !await taskValidations.TaskAlreadyCompleted(taskId, cancellationToken))
            .WithErrorCode(CompleteTaskCommandException<CompleteTaskCommand>.NotFound.Name);
    }
}