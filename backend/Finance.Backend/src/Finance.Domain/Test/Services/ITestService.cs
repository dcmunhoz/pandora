using Finance.Domain.Entities;
using Finance.Domain.Test.Commands;

namespace Finance.Domain.Test.Services
{
    public interface ITestService
    {
        public Task<Entities.Test> Test(NewTestCommand command);
    }
}
