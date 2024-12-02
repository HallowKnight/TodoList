using System;
using System.Threading;
using Domain.Aggregates.TaskAggregate;
using Domain.SeedWork;
using Infrastructure.Persistence.DbContext;

namespace Infrastructure.Repository.Task;

public class TaskCommandRepository(SqlDbContext context) : ITaskCommandRepository
{
    public IUnitOfWork UnitOfWork => context;

    public async System.Threading.Tasks.Task AddAsync(Domain.Aggregates.TaskAggregate.Task task,
        CancellationToken cancellationToken = default)
    {
        await context.Tasks.AddAsync(task, cancellationToken);
    }

    public void Update(Domain.Aggregates.TaskAggregate.Task task)
    {
        context.Tasks.Update(task);
    }

    public void Delete(Domain.Aggregates.TaskAggregate.Task task)
    {
        context.Tasks.Remove(task);
    }
}