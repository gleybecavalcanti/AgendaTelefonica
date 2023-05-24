using MediatR;
using Midway.Gleybe.Application.DTOs;

namespace Midway.Gleybe.Application.Pipelines
{
    public class ExceptionBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TResponse : HandlerResponse
    {

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            try
            {
                return await next();
            }
            catch (Exception exception)
            {
                return (TResponse)await Task.FromResult(new HandlerResponse() { HasError = true, Data = exception });
            }
        }
    }
}
