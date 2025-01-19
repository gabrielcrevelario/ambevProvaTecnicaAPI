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
    public class CartWriteRepository : ICartWriteRepository
    {
        private readonly DefaultContext _context;
        public async Task<Cart> AddAsync(Cart cart)
        {
           var newCart = await _context.Carts.AddAsync(cart);
            await _context.SaveChangesAsync();
            return newCart.Entity;
        }
        public async Task<Cart> UpdateAsync(Guid cartId, Cart cart) 
        {

            var saveCart =  _context.Carts.Update(cart);
            await _context.SaveChangesAsync();
            return saveCart.Entity;

        }

        public async Task<bool> DeleteAsync(Guid cartId) {
            Cart cart = await _context.Carts.FirstOrDefaultAsync(x => x.Id == cartId);
            if(cart == null) {
                return false;    
            }
            _context.Carts.Remove(cart);
            await _context.SaveChangesAsync();
            return true;
        }

      
    }
}
}
