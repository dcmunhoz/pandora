using Pandora.Application.Business.Example.Results;
using Pandora.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pandora.Application.Business.Example.Command.New
{
    public record AddTestCommand(string Username, string Password): IRequest<TestResult>;
}
