namespace Domain.Aggregates.TaskAggregate.Exceptions;

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