using Infrastructure.Persistence.DbContext;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Business.Application.Behaviors;

public class TransactionBehavior<TRequest, TResponse>(SqlDbContext sqlDbContext)
    : IPipelineBehavior<TRequest, TResponse?>
    where TRequest : notnull
{
    public async Task<TResponse?> Handle(TRequest request, RequestHandlerDelegate<TResponse?> next,
        CancellationToken cancellationToken)
    {
        TResponse? response = default;
        if (sqlDbContext.HasActiveTransaction) return await next();
        IExecutionStrategy strategy = sqlDbContext.Database.CreateExecutionStrategy();
        await strategy.ExecuteAsync(async () =>
        {
            await using IDbContextTransaction? transaction =
                await sqlDbContext.BeginTransactionAsync(cancellationToken);

            try
            {
                response = await next();
                if (transaction != null)
                    await sqlDbContext.CommitTransactionAsync(transaction, cancellationToken);
                await sqlDbContext.SaveEntitiesAsync(cancellationToken);
            }
            catch
            {
                // Rollback transaction on failure
                await sqlDbContext.RollbackTransactionAsync(cancellationToken);
                throw;
            }
        });
        return response;
    }
}