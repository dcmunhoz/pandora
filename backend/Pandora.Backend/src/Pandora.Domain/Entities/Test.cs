namespace Pandora.Domain.Entities
{
    public class Test
    {
        public Test() { }

        public Test(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public int Id { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }
        public DateTime? LastUpdate { get; private set; } = DateTime.Now;

    }
}
