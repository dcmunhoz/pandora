using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pandora.Application.Business.Authentication.Commands.Login;
using Pandora.Application.Business.Authentication.Commands.Register;
using Pandora.Application.Common.Notification;
using Pandora.Application.Dto.Authentication.Requests;
using Pandora.Application.Dto.Authentication.Responses;
using System.Net;

namespace Pandora.Api.Controllers.v1
{
    [ApiController]
    [Route("/api/v1/auth")]
    public class AuthenticationController : ControllerBase
    {
        public IMediator _mediator;

        public AuthenticationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// 
        /// Cadastra um novo usuário na aplicação via inscreva-se.
        /// 
        /// </summary>
        [HttpPost("signup")]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(NotificationResponse), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(RegisterNewUserResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterNewUserRequest request)
        {

            var command = request.MapTo<RegisterNewUserCommand>();

            var result = await _mediator.Send(command);

            return Ok(result.MapTo<RegisterNewUserResponse>());
        }

        /// <summary>
        /// 
        /// Realiza autenticação na aplicação.
        /// 
        /// </summary>
        [HttpPost("login")]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(NotificationResponse), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(NotificationResponse), (int)HttpStatusCode.Unauthorized)]
        //[ProducesResponseType(typeof(RESPONSE), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {

            var command = request.MapTo<LoginCommand>();
            var result = await _mediator.Send(command);

            return Ok(result.MapTo<UserAuthenticatedResponse>());
        }

    }
}
