using Pandora.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pandora.Application.Services.Authentication
{
    public interface IAuthService
    {
        public string GenerateToken(User user);
    }
}
