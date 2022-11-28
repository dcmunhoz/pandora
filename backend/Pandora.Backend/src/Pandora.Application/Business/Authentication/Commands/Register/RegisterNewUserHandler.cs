using MediatR;
using Pandora.Application.Business.Authentication.Results;
using Pandora.Application.Common.Interfaces.Repository;
using Pandora.Application.Common.Notification;
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

            var user = new User(request.Username, request.Password, request.Email, request.Name, request.LastName);

            user = await _userRepository.Insert(user);

            return user.MapTo<UserRegistredResult>();
        }
    }
}
