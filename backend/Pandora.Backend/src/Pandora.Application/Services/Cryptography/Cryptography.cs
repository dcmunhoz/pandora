using System.Security.Cryptography;
using System.Text;

namespace Pandora.Application.Services.Cryptography
{
    public static class Cryptography
    {
        public static string Encrypt(string plainString)
        {
            using (SHA256 sha256 = SHA256.Create())
            {

                byte[] stringBytes = Encoding.UTF8.GetBytes(plainString);
                byte[] bytes = sha256.ComputeHash(stringBytes);

                StringBuilder sb = new();

                foreach (byte b in bytes)
                {

                    sb.Append(b.ToString("X2"));

                }

                return sb.ToString();

            }
        }
    }
}
