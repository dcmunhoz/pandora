using MediatR;
using Pandora.Application.Business.Authentication.Results;
using Pandora.Application.Common.Interfaces.Repository;
using Pandora.Application.Common.Notification;
using Pandora.Application.Services.Cryptography;
using Pandora.Domain.Entities;

namespace Pandora.Application.Business.Authentication.Commands.Register
{
    public class RegisterNewUserHandler : IRequestHandler<RegisterNewUserCommand, UserRegistredResult>
    {
        private INotificationHandler _notification;
        private IUserRepository _userRepository;

        public RegisterNewUserHandler(INotificationHandler notification, IUserRepository userRepository)
        {
            _notification = notification;
            _userRepository = userRepository;
        }

        public async Task<UserRegistredResult> Handle(RegisterNewUserCommand request, CancellationToken cancellationToken)
        {
            _userRepository.BeginTransaction();


            if (await _userRepository.GetByEmailAsync(request.Email) is not null)
            {
                _notification
                    .Title("E-mail existente.")
                    .Detail($"O e-mail {request.Email} já esta cadastrado.")
                    .Raise();

                return default;
            }

            if (await _userRepository.GetByUsernameAsync(request.Username) is not null)
            {
                _notification
                    .Title("Usuário existente.")
                    .Detail($"O usuário {request.Username} já esta cadastrado.")
                    .Raise();

                return default;
            }


            string newPassword = Cryptography.Encrypt(request.Password);

            var user = new User(request.Username, newPassword, request.Email, request.Name, request.LastName);

            user = await _userRepository.Insert(user);

            return user.MapTo<UserRegistredResult>();
        }
    }
}
