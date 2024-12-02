using Domain.SeedWork;

namespace Domain.Aggregates.TaskAggregate;

public interface ITaskCommandRepository : IRepository<Task>
{
    System.Threading.Tasks.Task AddAsync(Task task, CancellationToken cancellationToken = default);
    void Update(Task task);
    void Delete(Task task);
}