using Finance.Infra.Postgres.Mapping;
using Finance.Infra.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Infra.Postgres
{
    public class FinancePostgresContext: FinanceDbContext
    {
        public FinancePostgresContext(DbContextOptions<FinanceDbContext> options): base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new TestMap());
        }
    }
}
