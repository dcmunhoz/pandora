using Pandora.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pandora.Application.Common.Interfaces.Token
{
    public interface ITokenService
    {
        public string GetToken(User user);
    }
}
