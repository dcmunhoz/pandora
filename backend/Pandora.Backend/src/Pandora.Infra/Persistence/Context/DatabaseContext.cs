using Pandora.Domain.Entities;
using Pandora.Infra.Repository.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Pandora.Infra.Repository.Context
{
    public class DatabaseContext : DbContext, IDatabaseContext
    {
        public DbSet<Test> Tests { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> option) : base(option) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new TestMap());
        }

    }
}
