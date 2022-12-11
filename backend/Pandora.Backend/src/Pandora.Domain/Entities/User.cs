using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Pandora.Domain.Entities
{
    public class User
    {
        public Guid Id { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }
        public string Email { get; private set; }
        public string Name { get; private set; }
        public string LastName { get; private set; }
        public DateTime CreationDate { get; private set; }

        [ExcludeFromCodeCoverage]
        protected User() { }

        public User(string username, string password, string email, string name, string lastname)
        {
            Username = username;
            Password = password;
            Email = email;
            Name = name;
            LastName = lastname;

            Id = Guid.NewGuid();
            CreationDate = DateTime.Now;

        }

    }
}
