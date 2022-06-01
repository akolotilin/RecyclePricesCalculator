using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace VmsInform.Common.Behaviors
{
    internal sealed class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators ?? throw new ArgumentNullException(nameof(validators));
        }

        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var failures = _validators.Select(v => v.Validate(request))
                .Where(a => !a.IsValid)
                .SelectMany(a => a.Errors)
                .Where(e => e != null);

            if (failures.Any())
            {
                var errors = failures
                    .Select(a => a.ErrorMessage)
                    .Aggregate((a, b) => $"{a}, {b}");

                throw new ValidationException($"Validation errors for command {typeof(TRequest).Name}: {errors}", failures);
            }

            return next();
        }
    }
}
