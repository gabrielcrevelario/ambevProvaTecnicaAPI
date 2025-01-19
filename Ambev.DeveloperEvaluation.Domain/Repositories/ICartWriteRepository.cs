using Ambev.DeveloperEvaluation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Repositories
{
    public interface ICartWriteRepository
    {
        Task<Cart> AddAsync(Cart cart);
        Task<Cart> UpdateAsync(Guid cartId, Cart cart);
        Task<bool> DeleteAsync(Guid cartId);

    }
}
