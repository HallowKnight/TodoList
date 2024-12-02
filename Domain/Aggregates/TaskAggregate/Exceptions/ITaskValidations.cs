namespace Domain.Aggregates.TaskAggregate.Exceptions;

public interface ITaskValidations
{
    Task<bool> TaskExistAsync(Guid taskId, CancellationToken cancellationToken);
    Task<bool> TaskAlreadyCompleted(Guid taskId, CancellationToken cancellationToken);
}