using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pandora.Application.Business.Categories.Commands;
using Pandora.Application.Common.Notification;
using Pandora.Application.Dto.Category.Requests;
using Pandora.Application.Dto.Category.Responses;
using System.Net;

namespace Pandora.Api.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator; 
        }

        /// <summary>
        /// 
        /// Cria uma nova categoria
        /// 
        /// </summary>
        [HttpPost()]
        [ProducesResponseType(typeof(CreateCategoryResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(NotificationResponse), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryRequest request)
        {

            var result = await _mediator.Send(request.MapTo<CreateCategoryCommand>());

            return Ok(result.MapTo<CreateCategoryResponse>());
        }
    }
}
