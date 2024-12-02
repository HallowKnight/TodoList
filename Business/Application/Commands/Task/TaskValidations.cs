using Domain.Aggregates.TaskAggregate;
using Domain.Aggregates.TaskAggregate.Exceptions;

namespace Business.Application.Commands.Task;

public abstract class TaskValidations(ITaskQueryRepository taskQueryRepository) : ITaskValidations
{
    public static bool ExceededTitleMaxLenght(string? title)
    {
        return title is null || title.Length > 100;
    }

    public static bool ValidDueDate(DateTime? dueDate)
    {
        return dueDate is null || dueDate <= DateTime.Now;
    }
    
    public static bool ValidDueDate(DateTime dueDate)
    {
        return dueDate <= DateTime.Now;
    }

    public async Task<bool> TaskExistAsync(Guid taskId, CancellationToken cancellationToken)
    {
        return await taskQueryRepository.ExistsAsync(taskId, cancellationToken);
    }
    
    public async Task<bool> TaskAlreadyCompleted(Guid taskId, CancellationToken cancellationToken)
    {
        return await taskQueryRepository.IsTaskCompletedAsync(taskId, cancellationToken);
    }

}