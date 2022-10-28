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

        private readonly IDBContext _context;

        public TestRepository(IDBContext context)
        {
            _context = context;
        }

        public async Task<Test> AddAsync(Test entity)
        {

            _context.Tests.Add(entity);

            _context.SaveChanges();

            return entity;
        }
    }
}
