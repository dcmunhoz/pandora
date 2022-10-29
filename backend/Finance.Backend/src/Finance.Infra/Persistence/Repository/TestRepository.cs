﻿using Finance.Application.Common.Interfaces.Repository;
using Finance.Domain.Entities;
using Finance.Infra.Repository.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Infra.Persistence.Repository
{
    internal class TestRepository : ITestRepository
    {

        private readonly IFinanceDbContext _context;

        public TestRepository(IFinanceDbContext context)
        {
            _context = context;
        }

        public async Task<Test> AddAsync(Test entity)
        {

            await _context.Tests.AddAsync(entity);

            await _context.SaveChangesAsync();

            return entity;

        }

        public async Task<Test> GetById(int id)
        {
            var entity = await _context.Tests.FirstOrDefaultAsync(w => w.Id == id);

            if (entity is null) return default;


            return entity;
        }
    }
}
