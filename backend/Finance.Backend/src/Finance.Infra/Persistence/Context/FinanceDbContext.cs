using Finance.Domain.Entities;
using Finance.Infra.Repository.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Finance.Infra.Repository.Context
{
    public class FinanceDbContext : DbContext, IFinanceDbContext
    {
        public DbSet<Test> Tests { get; set; }

        public FinanceDbContext(DbContextOptions<FinanceDbContext> option) : base(option) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new TestMap());
        }

    }
}
