﻿using Pandora.Application.Common.Interfaces.Repository;
using Pandora.Domain.Entities;
using Pandora.Infra.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pandora.Infra.Persistence.Repository
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(IDatabaseContext context)
        {
            _context = context;
        }

        public async Task<User> Insert(User user)
        {

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;
        }
    }
}
