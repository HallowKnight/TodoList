using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace Business.Behaviors;

public class ValidatorBehavior<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> validators)
    : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        List<ValidationFailure> failures =
            (await Task.WhenAll(validators.Select(validator => validator.ValidateAsync(request, cancellationToken))))
            .SelectMany(result => result.Errors)
            .Where(error => error != null)
            .ToList();
        if (failures.Count == 0) return await next();
        throw new Exception(
            $"Command Validation Errors for type {typeof(TRequest).Name}",
            new ValidationException("Validation exception", failures));
    }
}