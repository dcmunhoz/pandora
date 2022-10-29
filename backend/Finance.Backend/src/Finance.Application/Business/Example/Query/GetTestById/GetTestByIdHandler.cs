using Finance.Application.Business.Example.Results;
using Finance.Application.Common.Interfaces.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Application.Business.Example.Query.GetTestById
{
    public class GetTestByIdHandler : IRequestHandler<GetTestByIdQuery, TestResult>
    {

        private readonly ITestRepository _repository;

        public GetTestByIdHandler(ITestRepository repository)
        {
            _repository = repository;   
        }

        public async Task<TestResult> Handle(GetTestByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetById(request.Id);

            if (entity is null)
            {
                return default;
            }

            TestResult result = new TestResult(entity.Id, entity.Username, entity.Password);

            return result;

        }
    }
}
