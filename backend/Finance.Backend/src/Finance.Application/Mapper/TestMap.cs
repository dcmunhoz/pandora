using AutoMapper;
using Finance.Application.Business.Example.Command.New;
using Finance.Application.Business.Example.Results;
using Finance.Application.Dto.Test.Requests;
using Finance.Application.Dto.Test.Responses;
using Finance.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Application.Mapper
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
