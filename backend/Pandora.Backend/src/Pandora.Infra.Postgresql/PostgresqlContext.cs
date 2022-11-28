using Pandora.Infra.Repository.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pandora.Infra.Postgresql.Mapping;

namespace Pandora.Infra.Postgresql
{
    public class PostgresqlContext: DatabaseContext
    {
        public PostgresqlContext( DbContextOptions<DatabaseContext> options ) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.HasDefaultSchema("public");

            builder.ApplyConfiguration(new UserMap());
        }
    }
}
