using Finance.Application.Dto.Test.Requests;
using Finance.Application.Dto.Test.Responses;

namespace Finance.Application.Interfaces.Services
{
    public interface ITestAppService
    {
        public NewTestResponse Test(NewTestRequest request);
    }
}
