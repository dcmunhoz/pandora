using Finance.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Domain.Interfaces.Repository
{
    public interface ITestRepository
    {
        public Task<Entities.Test> AddAsync(Entities.Test entity);
    }
}
