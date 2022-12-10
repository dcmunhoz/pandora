using MediatR;
using Pandora.Application.Business.Authentication.Results;

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
