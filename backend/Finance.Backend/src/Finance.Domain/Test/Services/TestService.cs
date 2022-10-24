using Finance.Domain.Interfaces.Repository;
using Finance.Domain.Test.Commands;

namespace Finance.Domain.Test.Services
{
    public class TestService : ITestService
    {
        private readonly ITestRepository _repository;

        public TestService(ITestRepository repository)
        {
            _repository = repository;
        }

        public async Task<Entities.Test> Test(NewTestCommand command)
        {
            var entity = new Entities.Test()
            {
                Username = command.Username,
                Password = command.Password,
                LastUpdate = DateTime.Now

            };

            entity = await _repository.AddAsync(entity);

            return entity;
        }
    }
}
