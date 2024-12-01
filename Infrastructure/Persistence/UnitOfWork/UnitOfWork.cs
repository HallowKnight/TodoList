using System;
using System.Threading;
using System.Threading.Tasks;
using Domain.SeedWork;
using Infrastructure.Persistence.DbContext;

namespace Infrastructure.Persistence.UnitOfWork;

public class UnitOfWork(SqlDbContext context) : IUnitOfWork
{
    public int SaveChanges()
    {
        return context.SaveChanges();
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await context.SaveChangesAsync(cancellationToken);
    }

    public void Dispose()
    {
        context.Dispose();
        GC.SuppressFinalize(this);
    }
}