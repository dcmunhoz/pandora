using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pandora.Application.Common.Interfaces.Repository
{
    public interface IBaseRepository
    {
        public IDbContextTransaction BeginTransaction();
    }
}
