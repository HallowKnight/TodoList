using Domain.SeedWork;

namespace Domain.Aggregates.TaskAggregate;

public interface ITaskQueryRepository : IRepository<Task>
{
    Task<Domain.Aggregates.TaskAggregate.Task?> GetAsync(Guid taskId, CancellationToken cancellationToken);
    Task<bool> ExistsAsync(Guid taskId, CancellationToken cancellationToken);
    Task<bool> IsTaskCompletedAsync(Guid taskId, CancellationToken cancellationToken);
}