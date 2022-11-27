using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Formatters;
using System.Net;

namespace Pandora.Api.Filters
{
    public class ExceptionFilter: ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            base.OnException(context);

            var mediaTypes = new MediaTypeCollection();
            mediaTypes.Add("application/problem+json");

            var problem = new ProblemDetails()
            {
                Type = "https://www.rfc-editor.org/rfc/rfc7231#section-6.6.1",
                Title = "Ocorreu um erro ao processar a requisição.",
                Detail = context.Exception.Message,
                Status = (int)HttpStatusCode.InternalServerError,
                Instance = context.HttpContext.Request.Path
            };

            var result = new ObjectResult(problem)
            {
                ContentTypes = mediaTypes
            };

            context.Result = result;

        }
    }
}
