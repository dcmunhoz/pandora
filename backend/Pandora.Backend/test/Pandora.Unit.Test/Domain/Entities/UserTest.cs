using Pandora.Domain.Entities;

namespace Pandora.Unit.Test.Domain.Entities
{
    
    public class UserTest
    {

        [Theory]
        [InlineData("user", "12345", "test@test.com", "User", "Test")]
        public static void It_Shuld_Create_User_Successfully(string username, string password, string email, string name, string lastName)
        {
            // Arrange
            // Act
            User user = new(username, password, email, name, lastName);


            //Assert
            Assert.NotNull(user);
            Assert.Equal(username, user.Username);
            Assert.Equal(password, user.Password);
            Assert.Equal(email, user.Email);
            Assert.Equal(name, user.Name);
            Assert.Equal(lastName, user.LastName);
        }

        [Theory]
        [InlineData("user", "12345", "test@test.com", "User", "Test")]
        public static void It_Should_Create_User_With_Valid_Guid(string username, string password, string email, string name, string lastName)
        {
            var guid = new Guid();

            User user = new(username, password, email, name, lastName);

            Assert.NotEqual(guid, user.Id);
        }

    }
}
