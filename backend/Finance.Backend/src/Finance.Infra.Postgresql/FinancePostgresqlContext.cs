using Finance.Infra.Postgresql.Mapping;
using Finance.Infra.Repository.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Infra.Postgresql
{
    public class FinancePostgresqlContext: FinanceDbContext
    {
        public FinancePostgresqlContext( DbContextOptions<FinanceDbContext> options ) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.HasDefaultSchema("public");
            builder.ApplyConfiguration(new TestMap());
        }
    }
}
