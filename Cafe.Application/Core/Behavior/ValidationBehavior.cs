using Cafe.Application.Common;
using FluentValidation;
using MediatR;

namespace Cafe.Application.Core.Behavior
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : BaseResponse<object>, new()
    {
        private readonly IValidator<TRequest>? _validator;

        public ValidationBehavior(IValidator<TRequest>? validator)
        {
            _validator = validator;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (_validator != null)
            {
                var validationResult = await _validator.ValidateAsync(request, cancellationToken);
                if (!validationResult.IsValid)
                {
                    var errorMessage = string.Join(", ", validationResult.Errors
                        .Select(error => $"{error.PropertyName}: {error.ErrorMessage}"));

                    return new TResponse
                    {
                        Message = errorMessage,
                        Success = false,
                        StatusCode = 400,
                    };
                }
            }

            return await next();
        }
    }
}