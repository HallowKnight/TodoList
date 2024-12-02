namespace Domain.Aggregates.TaskAggregate.Exceptions.ErrorEnums;

public enum EditTaskErrorEnum
{
    NotFound,
    AlreadyDone,
    TitleRequired,
    DescriptionRequired,
    DueDateRequired,
    TitleMaxLengthExceeded,
    InvalidDueDate
}