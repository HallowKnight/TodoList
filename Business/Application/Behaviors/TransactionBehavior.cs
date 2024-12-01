using Infrastructure.Persistence.DbContext;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Business.Behaviors;

public class TransactionBehavior<TRequest, TResponse>(SqlDbContext dbContext) : IPipelineBehavior<TRequest, TResponse?>
    where TRequest : IRequest<TResponse?>
{
    public async Task<TResponse?> Handle(TRequest request, RequestHandlerDelegate<TResponse?> next,
        CancellationToken cancellationToken)
    {
        TResponse? response = default;
        if (dbContext.HasActiveTransaction) return await next();
        IExecutionStrategy strategy = dbContext.Database.CreateExecutionStrategy();
        await strategy.ExecuteAsync(async () =>
        {
            await using IDbContextTransaction transaction =
                await dbContext.Database.BeginTransactionAsync(cancellationToken);
            await dbContext.CommitTransactionAsync(transaction);
            await dbContext.SaveEntitiesAsync(cancellationToken);
        });
        return response;
    }
}