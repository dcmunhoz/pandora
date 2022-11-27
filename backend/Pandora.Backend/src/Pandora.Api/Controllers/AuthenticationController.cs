using Microsoft.AspNetCore.Mvc;
using Pandora.Application.Common.Notification;
using System.Net;

namespace Pandora.Api.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class AuthenticationController : ControllerBase
    {

        public INotificationHandler _notification;

        public AuthenticationController(INotificationHandler notification)
        {
            _notification = notification;
        }

        /// <summary>
        /// Cadastra um novo usuário na aplicação via inscreva-se.
        /// </summary>
        [HttpPost]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(NotificationResponse), (int)HttpStatusCode.BadRequest)]
        public IActionResult RegisterUser()
        {

            _notification
                .Title("Você não pode fazer isso")
                .Detail("Por causa disso")
                .Status(HttpStatusCode.AlreadyReported)
                .Raise();

            return Ok();
        }

    }
}
