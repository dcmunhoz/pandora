using Finance.Domain.Entities;
using Finance.Domain.Test.Commands;

namespace Finance.Domain.Interfaces.Services
{
    public interface ITestService
    {
        public Entities.Test Test(NewTestCommand command);
    }
}
