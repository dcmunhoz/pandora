using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Pandora.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pandora.Infra.Repository.Context
{
    public interface IDatabaseContext
    {

        #region DbSets

        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }

        #endregion

        public DatabaseFacade Database { get; }

        public int SaveChanges();

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
