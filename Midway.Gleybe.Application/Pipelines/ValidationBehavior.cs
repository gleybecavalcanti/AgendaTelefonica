using FluentValidation;
using MediatR;
using Midway.Gleybe.Application.DTOs;
using Midway.Gleybe.Domain.Constants;

namespace Midway.Gleybe.Application.Pipelines
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TResponse : class
    {
        private readonly IEnumerable<IValidator<TRequest>> validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            this.validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            if (validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);
                var validationResults = await Task.WhenAll(validators.Select(v => v.ValidateAsync(context, cancellationToken)));

                var failures = validationResults.SelectMany(r => r.Errors).Where(f => f != null).ToList();

                if (failures.Any())
                {
                    var errorResponse = new
                    {
                        Message = Messages.DefaultValidationErrors,
                        Errors = failures.Select(failure => new
                        {
                            failure.PropertyName,
                            failure.ErrorMessage
                        }).ToList()
                    };

                    return (TResponse)(object)new HandlerResponse() { Data = errorResponse, HasError = true };
                }
            }

            return await next();
        }
    }
}
