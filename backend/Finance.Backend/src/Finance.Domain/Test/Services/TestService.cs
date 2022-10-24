using Finance.Domain.Interfaces.Services;
using Finance.Domain.Test.Commands;

namespace Finance.Domain.Test.Services
{
    public class TestService : ITestService
    {
        public Entities.Test Test(NewTestCommand command)
        {
            var entity = new Entities.Test()
            {
                Id = 11,
                Username = command.Username,
                Password = command.Password,
                LastUpdate = DateTime.Now

            };

            return entity;
        }
    }
}
