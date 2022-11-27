using System;
using Pandora.Application.Business.Example.Command.New;
using Pandora.Application.Business.Example.Query.GetTestById;
using Pandora.Application.Dto.Test.Requests;
using Pandora.Application.Dto.Test.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Pandora.Api.Controllers
{
    [ApiController]
    [Route("/api/v1/[Controller]")]
    public class TestController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ISender _sender;

        public TestController(IMediator mediator, ISender sender)
        {
            _mediator = mediator;
            _sender = sender;
        }

        [HttpPost]
        [ProducesResponseType(typeof(NewTestResponse), 200)]
        public async Task<IActionResult> PostTest([FromBody] NewTestRequest request )
        {

            var command = request.MapTo<AddTestCommand>();

            var result = (await _mediator.Send(command)).MapTo<NewTestResponse>();

            return Ok(result);
        }


        [HttpGet("{Id}")]
        [ProducesResponseType(typeof(NewTestResponse), 200)]
        [ProducesResponseType(typeof(NotFoundResult), 404)]
        public async Task<IActionResult> GetById(int Id)
        {
            var query = new GetTestByIdQuery(Id);

            var entity = await _sender.Send(query);

            if (entity is null)
            {
                return NotFound();
            }

            return Ok(entity);

        }
    }
}
