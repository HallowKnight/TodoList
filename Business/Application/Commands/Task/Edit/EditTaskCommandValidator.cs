using Domain.Aggregates.TaskAggregate.Exceptions;
using FluentValidation;

namespace Business.Application.Commands.Task.Edit;

public class EditTaskCommandValidator : AbstractValidator<EditTaskCommand>
{
    public EditTaskCommandValidator()
    {
        // RuleFor(task => task.Id)
        //     .MustAsync(async (taskId, cancellationToken) =>
        //         await taskValidations.TaskExistAsync(taskId, cancellationToken))
        //     .WithErrorCode(EditTaskCommandException<EditTaskCommand>.NotFound.Name);
        //
        // RuleFor(task => task.Id)
        //     .MustAsync(async (taskId, cancellationToken) =>
        //         !await taskValidations.TaskAlreadyCompleted(taskId, cancellationToken))
        //     .WithErrorCode(EditTaskCommandException<EditTaskCommand>.AlreadyDone.Name);
        
        RuleFor(task => task.Title)
            .Must(TaskValidations.ExceededTitleMaxLenght)
            .WithErrorCode(EditTaskCommandException<EditTaskCommand>.TitleMaxLengthExceeded.Name);
        
        RuleFor(task => task.DueDate)
            .Must(TaskValidations.ValidDueDate)
            .WithErrorCode(EditTaskCommandException<EditTaskCommand>.InvalidDueDate.Name);
    }
}