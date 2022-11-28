using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Formatters;
using Pandora.Infra.Repository.Context;
using System.Net;

namespace Pandora.Api.Filters
{
    public class ExceptionFilter: ExceptionFilterAttribute
    {
        private IDatabaseContext _context;

        public ExceptionFilter(IDatabaseContext context)
        {
            _context = context;
        }

        public async override void OnException(ExceptionContext context)
        {
            base.OnException(context);

            var mediaTypes = new MediaTypeCollection();
            mediaTypes.Add("application/problem+json");

            var problem = new ProblemDetails()
            {
                Type = "https://www.rfc-editor.org/rfc/rfc7231#section-6.6.1",
                Title = "Ocorreu um erro ao processar a requisição.",
                Detail = context.Exception.Message + ( (String.IsNullOrEmpty(context.Exception.InnerException.ToString())) ? (" Inner Exception: " + context.Exception.InnerException) : "" ),
                Status = (int)HttpStatusCode.InternalServerError,
                Instance = context.HttpContext.Request.Path
            };

            var result = new ObjectResult(problem)
            {
                ContentTypes = mediaTypes
            };

            context.Result = result;

            var transaction = _context.Database.CurrentTransaction;

            if ( transaction != null)
            {
                await transaction.RollbackAsync();
            }


        }
    }
}
