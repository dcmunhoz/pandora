using Finance.Domain.Entities;
using Finance.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Infra.Repository
{
    internal class TestRepository : ITestRepository
    {

        private readonly FinanceDbContext _context;

        public TestRepository(FinanceDbContext context)
        {
            _context = context;
        }

        public async Task<Test> AddAsync(Test entity)
        {

            _context.Tests.Add(entity);

            await _context.SaveChangesAsync();

            return entity;
        }
    }
}
