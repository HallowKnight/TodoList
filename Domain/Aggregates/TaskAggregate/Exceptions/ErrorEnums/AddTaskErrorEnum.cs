namespace Domain.Aggregates.TaskAggregate.Exceptions.ErrorEnums;

public enum AddTaskErrorEnum
{
    TitleRequired = 0,
    DescriptionRequired = 1,
    DueDateRequired = 2,
    TitleMaxLengthExceeded = 3,
    InvalidDueDate = 4
}