using System.Threading;
using Domain.Aggregates.TaskAggregate;
using Domain.SeedWork;
using Infrastructure.Persistence.DbContext;

namespace Infrastructure.Repository.Task;

public class TaskCommandRepository(SqlDbContext context) : ITaskCommandRepository
{
    public IUnitOfWork UnitOfWork => context;

    public async System.Threading.Tasks.Task AddTaskAsync(Domain.Aggregates.TaskAggregate.Task task,
        CancellationToken cancellationToken = default)
    {
        await context.AddAsync(task, cancellationToken);
    }
}