using MediatR;
using Pandora.Application.Business.Authentication.Results;
using Pandora.Application.Common.Interfaces.Repository;
using Pandora.Application.Common.Notification;
using Pandora.Application.Services.Authentication;
using Pandora.Application.Services.Cryptography;
using System.Net;

namespace Pandora.Application.Business.Authentication.Commands.Login
{
    public class LoginHandler : IRequestHandler<LoginCommand, UserAuthenticatedResult>
    {
        private IUserRepository _userRepository;
        private INotificationHandler _notification;
        private IAuthService _authService;

        public LoginHandler(
            IUserRepository userRepository,
            INotificationHandler notification,
            IAuthService authService
        )
        {
            _userRepository = userRepository;
            _notification = notification;
            _authService = authService;
        }

        public async Task<UserAuthenticatedResult> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByUsernameAndPasswordAsync(request.Username, Cryptography.Encrypt(request.Password));

            if (user is null)
            {
                _notification
                    .Title("Falha na autenticação.")
                    .Detail("Usuário ou senha incorretos.")
                    .Status((int)HttpStatusCode.Unauthorized)
                    .Raise();

                return default;
            }

            var token = _authService.GenerateToken(user);
            var authResult = new UserAuthenticatedResult(token, user.Username, user.FullName);

            return authResult;
        }
    }
}
