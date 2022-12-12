using MediatR;
using Pandora.Application.Business.Authentication.Results;

namespace Pandora.Application.Business.Authentication.Commands.Login
{
    public record LoginCommand(string Username, string Password): IRequest<UserAuthenticatedResult>;
}
