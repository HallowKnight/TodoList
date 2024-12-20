using FluentValidation;

namespace Business.Application.Commands.Task.Add;

public class AddTaskCommandValidator : AbstractValidator<AddTaskCommand>
{
    public AddTaskCommandValidator()
    {
        RuleFor(task => task.Title)
            .NotEmpty()
            .WithErrorCode(AddTaskCommandException<AddTaskCommand>.TitleRequired.Name);
        
        RuleFor(task => task.Title)
            .Must(TaskValidations.ExceededTitleMaxLenght)
            .WithErrorCode(AddTaskCommandException<AddTaskCommand>.TitleMaxLengthExceeded.Name);

        RuleFor(task => task.Description)
            .NotEmpty()
            .WithErrorCode(AddTaskCommandException<AddTaskCommand>.DescriptionRequired.Name);
        
        RuleFor(task => task.DueDate)
            .NotEmpty()
            .WithErrorCode(AddTaskCommandException<AddTaskCommand>.DueDateRequired.Name);
        
        RuleFor(task => task.DueDate)
            .Must(TaskValidations.ValidDueDate)
            .WithErrorCode(AddTaskCommandException<AddTaskCommand>.InvalidDueDate.Name);
    }
}