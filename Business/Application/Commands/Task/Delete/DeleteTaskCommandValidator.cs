using Domain.Aggregates.TaskAggregate.Exceptions;
using FluentValidation;

namespace Business.Application.Commands.Task.Delete;

public class DeleteTaskCommandValidator : AbstractValidator<DeleteTaskCommand>
{
    public DeleteTaskCommandValidator(ITaskValidations taskValidations)
    {
        RuleFor(task => task.Id)
            .MustAsync(async (taskId, cancellationToken) =>
                await taskValidations.TaskExistAsync(taskId, cancellationToken))
            .WithErrorCode(DeleteTaskCommandException<DeleteTaskCommand>.NotFound.Name);
    }
}