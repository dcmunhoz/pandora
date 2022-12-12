using Microsoft.EntityFrameworkCore.Storage;
using Pandora.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pandora.Application.Common.Interfaces.Repository
{
    public interface IUserRepository: IBaseRepository
    {
        public Task<User> Insert(User user);
        public Task<User> GetByUsernameAsync(string username);
        public Task<User> GetByEmailAsync(string email);
        public Task<User> GetByUsernameAndPasswordAsync(string username, string password);

    }
}
