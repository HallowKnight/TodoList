using Domain.Aggregates.TaskAggregate;

namespace Business.Actions.Task;

public static class TaskValidations
{
    public static bool ExceededTitleMaxLenght(string title)
    {
        return title.Length > 100;
    }

    public static bool ValidDueDate(DateTime dueDate)
    {
        return dueDate <= DateTime.Now;
    }
}