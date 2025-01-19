﻿using Ambev.DeveloperEvaluation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Repositories
{
    public interface ICartReadRepository
    {
        Task<Cart> GetByIdAsync(Guid id);
        Task<List<Cart>> GetAllAsync();
    }
}
