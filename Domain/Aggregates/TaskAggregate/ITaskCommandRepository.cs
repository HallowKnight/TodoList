using Domain.SeedWork;

namespace Domain.Aggregates.TaskAggregate;

public interface ITaskCommandRepository : IRepository<Task>
{
    System.Threading.Tasks.Task AddTaskAsync(Task task, CancellationToken cancellationToken = default);
}