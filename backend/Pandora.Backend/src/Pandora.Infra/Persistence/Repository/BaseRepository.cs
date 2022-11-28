using Microsoft.EntityFrameworkCore.Storage;
using Pandora.Application.Common.Interfaces.Repository;
using Pandora.Infra.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pandora.Infra.Persistence.Repository
{
    public abstract class BaseRepository: IBaseRepository
    {
        protected IDatabaseContext _context;

        public IDbContextTransaction BeginTransaction()
        {
            return _context.Database.BeginTransaction();
        }
    }
}
