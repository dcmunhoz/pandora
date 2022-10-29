using Finance.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Application.Common.Interfaces.Repository
{
    public interface ITestRepository
    {
        public Task<Test> AddAsync(Test test);
        public Task<Test> GetById(int id);
    }
}
