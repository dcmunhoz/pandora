using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Pandora.Infra.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pandora.Unit.Test.Application
{
    public class SqlLiteDbContext : DatabaseContext
    {
        public SqlLiteDbContext(DbContextOptions<DatabaseContext> options) : base(options) { }

    }
}
