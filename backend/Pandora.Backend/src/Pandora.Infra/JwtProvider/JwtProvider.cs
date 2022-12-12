using Microsoft.IdentityModel.Tokens;
using Pandora.Application.Common.Interfaces.Token;
using Pandora.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Pandora.Infra.JwtProvider
{
    public class JwtProvider : ITokenService
    {

        public string GetToken(User user)
        {
            var claims = new Claim[]
            {
                new(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new(JwtRegisteredClaimNames.Email, user.Email)

            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("super-secret-key");
            var credentias = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = credentias
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            var tokenValue = tokenHandler.WriteToken(token);

            return tokenValue;
        }
    }
}
