using Finance.Application.Dto.Test.Requests;
using Finance.Application.Dto.Test.Responses;
using Finance.Application.Interfaces.Services;
using Finance.Domain.Interfaces.Services;
using Finance.Domain.Test.Commands;

namespace Finance.Application.Services
{
    public class TestAppService : ITestAppService
    {

        private readonly ITestService _service;

        public TestAppService(ITestService service)
        {
            _service = service;
        }

        public NewTestResponse Test(NewTestRequest request)
        {

            var command = new NewTestCommand()
            {
                Username = request.Username,
                Password = request.Password
            };

            var entity = _service.Test(command);

            var response = new NewTestResponse()
            {
                Id = entity.Id
            };
            
            return response;
        }
    }
}
