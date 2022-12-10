using FluentValidation;
using MediatR;
using Pandora.Application.Common.Notification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pandora.Application.Common.Behavior
{
    public class ValidationsBehavior<TRequest, TResponse>:
        IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {

        private readonly IValidator<TRequest>? _validator;
        private readonly INotificationHandler _notification;

        public ValidationsBehavior(INotificationHandler notification, IValidator<TRequest>? validator = null)
        {
            _validator = validator;
            _notification = notification;
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
                var errors = new List<string>();

                foreach(var item in result.Errors)
                {
                    errors.Add(item.ErrorMessage);
                }

                _notification
                    .Title("Ocorreram erros de validação.")
                    .Detail(errors)
                    .Raise();

                return default;
            }

            return await next();

        }
    }
}
