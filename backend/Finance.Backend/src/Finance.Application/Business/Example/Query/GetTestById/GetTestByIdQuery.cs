using Finance.Application.Business.Example.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Application.Business.Example.Query.GetTestById
{
    public record GetTestByIdQuery(int Id): IRequest<TestResult>;
}
