using AutoMapper;
using Pandora.Application.Business.Example.Command.New;
using Pandora.Application.Business.Example.Results;
using Pandora.Application.Dto.Test.Requests;
using Pandora.Application.Dto.Test.Responses;
using Pandora.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pandora.Application.Mapper
{
    public class TestMap: Profile
    {
        public TestMap()
        {
            CreateMap<NewTestRequest, AddTestCommand>();
            CreateMap<Test, TestResult>();
            CreateMap<TestResult, NewTestResponse>();
        }
    }
}
