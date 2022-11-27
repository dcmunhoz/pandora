using AutoMapper;
using Pandora.Application.Business.Example.Command.New;
using Pandora.Application.Business.Example.Results;
using Pandora.Application.Common.Interfaces.Repository;
using Pandora.Domain.Entities;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pandora.Application.Business.Example.Command.Add
{
    public class AddTestCommandHandler : IRequestHandler<AddTestCommand, TestResult>
    {
        private readonly ITestRepository _repository;

        public AddTestCommandHandler(ITestRepository repository)
        {
            _repository = repository;
        }

        public async Task<TestResult> Handle(AddTestCommand request, CancellationToken cancellationToken)
        {
            var test = new Test(request.Username, request.Password);

            await _repository.AddAsync(test);

            return test.MapTo<TestResult>();
        }
    }
}
