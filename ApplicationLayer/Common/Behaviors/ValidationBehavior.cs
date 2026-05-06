using ErrorOr;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationLayer.Common.Behaviors
{
    public class ValidationBehavior<TRequest, TResponse>
     : IPipelineBehavior<TRequest, TResponse>
     where TRequest : IRequest<TResponse>
     where TResponse : IErrorOr // قيد لضمان أن الرد يدعم ErrorOr
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request,
            RequestHandlerDelegate<TResponse> next,
            CancellationToken cancellationToken)
        {
            if (!_validators.Any()) return await next();

            var context = new ValidationContext<TRequest>(request);

            // تشغيل كل الـ Validators بالتوازي
            var validationResults = await Task.WhenAll(
                _validators.Select(v => v.ValidateAsync(context, cancellationToken)));

            // تجميع كل الأخطاء
            var errors = validationResults
                .SelectMany(r => r.Errors)
                .Where(f => f != null)
                .Select(failure => Error.Validation(failure.PropertyName, failure.ErrorMessage))
                .ToList();

            if (errors.Any())
            {
                // بدلاً من throw Exception، نرجع قائمة الأخطاء بشكل صريح
                return (dynamic)errors;
            }

            return await next();
        }
    }
}
