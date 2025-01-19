using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.ORM.Repositories
{
    public class CartReadRepository : ICartReadRepository
    {
        private readonly DefaultContext _context;
        public async Task<List<Cart>> GetAllAsync()
        {
            var listCarts = await _context.Carts.ToListAsync();
            return listCarts;
        }

        public async Task<Cart> GetByIdAsync(Guid id)
        {
            var cart = await _context.Carts.FirstOrDefaultAsync(c => c.Id == id);
            return cart;
        }
    }
}
