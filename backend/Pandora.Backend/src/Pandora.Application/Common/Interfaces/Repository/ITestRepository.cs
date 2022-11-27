using Pandora.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pandora.Application.Common.Interfaces.Repository
{
    public interface ITestRepository
    {
        public Task<Test> AddAsync(Test test);
        public Task<Test> GetById(int id);
    }
}
