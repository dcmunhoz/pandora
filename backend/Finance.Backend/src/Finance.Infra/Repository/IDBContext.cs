﻿using Finance.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Infra.Repository
{
    public interface IDBContext
    {
        public DbSet<Test> Tests { get; set; }

        public int SaveChanges();
    }
}