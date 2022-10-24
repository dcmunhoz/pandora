using Finance.Application.Dto.Test.Requests;
using Finance.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Finance.Api.Controllers
{
    [ApiController]
    [Route("/api/v1/[Controller]")]
    public class TestController : ControllerBase
    {
        private readonly ITestAppService _service;

        public TestController(ITestAppService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult PostTest([FromBody] NewTestRequest request )
        {
            return Ok( _service.Test(request) );
        }
    }
}
