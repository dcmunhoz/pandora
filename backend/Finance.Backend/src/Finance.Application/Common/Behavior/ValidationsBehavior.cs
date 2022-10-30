using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Application.Common.Behavior
{
    public class ValidationsBehavior<TRequest, TResponse>:
        IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {

        private readonly IValidator<TRequest>? _validator;

        public ValidationsBehavior(IValidator<TRequest>? validator = null)
        {
            _validator = validator;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {

            if (_validator is null)
            {
                return await next();

            }

            var result = await _validator.ValidateAsync(request);

            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }


            return await next();

        }
    }
}
