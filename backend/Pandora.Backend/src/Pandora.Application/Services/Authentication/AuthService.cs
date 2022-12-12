using Pandora.Application.Common.Interfaces.Token;
using Pandora.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pandora.Application.Services.Authentication
{
    public class AuthService : IAuthService
    {
        private ITokenService _tokenService;

        public AuthService(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        public string GenerateToken(User user)
        {
            return _tokenService.GetToken(user);
        }
    }
}
