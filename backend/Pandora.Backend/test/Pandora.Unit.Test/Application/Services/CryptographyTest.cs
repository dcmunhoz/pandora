using Pandora.Application.Services.Cryptography;
using System.Security.Cryptography;
using System.Text;

namespace Pandora.Unit.Test.Application.Services
{
    public class CryptographyTest
    {

        [Fact]
        public static void It_Shult_Cryoto_String()
        {
            string plainString = "Some string to be coverted";

            string encryptedString = Cryptography.Encrypt(plainString);

            Assert.NotNull(encryptedString);
            Assert.NotEqual(plainString, encryptedString);
            Assert.Equal(64, encryptedString.Length);

        }

    }
}
