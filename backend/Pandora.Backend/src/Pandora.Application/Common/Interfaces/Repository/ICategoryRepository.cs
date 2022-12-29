﻿using Pandora.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pandora.Application.Common.Interfaces.Repository
{
    public interface ICategoryRepository: IBaseRepository
    {
        Task<Category> AddAsync(Category category);
    }
}
