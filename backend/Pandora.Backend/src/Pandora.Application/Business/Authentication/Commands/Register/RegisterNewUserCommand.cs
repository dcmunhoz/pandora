using MediatR;
using Pandora.Application.Business.Authentication.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pandora.Application.Business.Authentication.Commands.Register
{
    public record RegisterNewUserCommand(
        string Username,
        string Password,
        string ConfirmedPassword,
        string Email,
        string Name,
        string LastName
    ) : IRequest<UserRegistredResult>;

}
