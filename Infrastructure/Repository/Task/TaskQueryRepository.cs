using System;
using System.Threading;
using System.Threading.Tasks;
using Domain.Aggregates.TaskAggregate;
using Domain.SeedWork;
using Infrastructure.Persistence.DbContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository.Task;

public class TaskQueryRepository(SqlDbContext context)  : ITaskQueryRepository
{
    public IUnitOfWork UnitOfWork => context;

    public async Task<Domain.Aggregates.TaskAggregate.Task?> GetAsync(Guid taskId, CancellationToken cancellationToken)
    {
        return await context.Tasks.FirstOrDefaultAsync(task => task.Id == taskId, cancellationToken);
    }

    public async Task<bool> ExistsAsync(Guid taskId, CancellationToken cancellationToken)
    {
        return await context.Tasks.AnyAsync(task => task.Id == taskId, cancellationToken);
    }
    
    public async Task<bool> IsTaskCompletedAsync(Guid taskId, CancellationToken cancellationToken)
    {
        return await context.Tasks.AnyAsync(task => task.Id == taskId && task.IsCompleted, cancellationToken);
    }
}