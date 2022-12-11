using Bogus;
using Bogus.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Pandora.Application.Business.Authentication.Commands.Register;
using Pandora.Application.Business.Authentication.Results;
using Pandora.Application.Common.Interfaces.Repository;
using Pandora.Application.Common.Notification;
using Pandora.Domain.Entities;
using Pandora.Infra.Persistence.Repository;
using Pandora.Infra.Repository.Context;

namespace Pandora.Unit.Test.Application.Handlers.Authentication
{
    public class RegisterNewUserHandlerTest : BaseTest
    {

        private IUserRepository _repository;
        private Faker _faker = new Faker();

        public RegisterNewUserHandlerTest()
        {

            _repository = Resolve<IUserRepository>();

        }

        [Fact]
        public async void It_Shuld_Register_New_User()
        {
            var handler = new RegisterNewUserHandler(Resolve<INotificationHandler>(), Resolve<IUserRepository>());

            var command = new RegisterNewUserCommand(
                _faker.Name.FirstName().ClampLength(max: 16),    
                _faker.Random.Words().ClampLength(max: 64),
                _faker.Random.Words().ClampLength(max: 64),
                _faker.Random.Words().ClampLength(max: 255),
                _faker.Name.FirstName().ClampLength(max: 100),
                _faker.Name.LastName().ClampLength(max: 100)
            );

            var result = await handler.Handle(command, default);

            Assert.NotNull(result);
            Assert.IsType<UserRegistredResult>(result);

        }

        [Fact]
        public async void It_Shuld_Not_Register_User_With_Existing_Username()
        {
            // Arrange
            var context = Resolve<IDatabaseContext>();

            var userName = _faker.Name.FirstName().ClampLength(max: 16);

            var user = new User(
                userName,
                _faker.Random.Words().ClampLength(max: 64),
                _faker.Random.Words().ClampLength(max: 255),
                _faker.Name.FirstName().ClampLength(max: 100),
                _faker.Name.LastName().ClampLength(max: 100));

            context.Users.Add(user);
            context.SaveChanges();

            // Act
            var handler = new RegisterNewUserHandler(Resolve<INotificationHandler>(), Resolve<IUserRepository>());

            var command = new RegisterNewUserCommand(
                userName,
                _faker.Random.Words().ClampLength(max: 64),
                _faker.Random.Words().ClampLength(max: 64),
                _faker.Random.Words().ClampLength(max: 255),
                _faker.Name.FirstName().ClampLength(max: 100),
                _faker.Name.LastName().ClampLength(max: 100)
            );

            var result = await handler.Handle(command, default);

            Assert.Null(result);

        }

        [Fact]
        public async void It_Shuld_Not_Register_User_With_Existing_Email()
        {
            // Arrange
            var context = Resolve<IDatabaseContext>();

            var email = _faker.Name.FirstName().ClampLength(max: 255);

            var user = new User(
                _faker.Name.FirstName().ClampLength(max: 16),
                _faker.Random.Words().ClampLength(max: 64),
                email,
                _faker.Name.FirstName().ClampLength(max: 100),
                _faker.Name.LastName().ClampLength(max: 100));

            context.Users.Add(user);
            context.SaveChanges();

            // Act
            var handler = new RegisterNewUserHandler(Resolve<INotificationHandler>(), Resolve<IUserRepository>());

            var command = new RegisterNewUserCommand(
                _faker.Name.FirstName().ClampLength(max: 16),
                _faker.Random.Words().ClampLength(max: 64),
                _faker.Random.Words().ClampLength(max: 64),
                email,
                _faker.Name.FirstName().ClampLength(max: 100),
                _faker.Name.LastName().ClampLength(max: 100)
            );

            var result = await handler.Handle(command, default);

            Assert.Null(result);

        }

    }
}