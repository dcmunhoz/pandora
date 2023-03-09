using Microsoft.EntityFrameworkCore;
using Pandora.Domain.Entities;
using Pandora.Infra.Persistence.Mapping;

namespace Pandora.Infra.Repository.Context
{
    public class DatabaseContext : DbContext, IDatabaseContext
    {

        #region DBsets

        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }

        #endregion

        public DatabaseContext(DbContextOptions<DatabaseContext> option) : base(option) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new UserMap());
            builder.ApplyConfiguration(new CategoryMap());
        }

    }
}
