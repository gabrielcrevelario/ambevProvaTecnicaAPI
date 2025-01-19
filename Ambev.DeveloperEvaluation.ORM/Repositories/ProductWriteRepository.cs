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
    public class ProductWriteRepository : IProductWriteRepository
    {
        private readonly DefaultContext _context;
        public async Task<Product> AddAsync(Product Product)
        {
           var newProduct = await _context.Products.AddAsync(Product);
            await _context.SaveChangesAsync();
            return newProduct.Entity;
        }
        public async Task<Product> UpdateAsync(Guid ProductId, Product Product) 
        {

            var saveProduct =  _context.Products.Update(Product);
            await _context.SaveChangesAsync();
            return saveProduct.Entity;

        }

        public async Task<bool> DeleteAsync(Guid ProductId) {
            Product Product = await _context.Products.FirstOrDefaultAsync(x => x.Id == ProductId);
            if(Product == null) {
                return false;    
            }
            _context.Products.Remove(Product);
            await _context.SaveChangesAsync();
            return true;
        }

      
    }
}
}
