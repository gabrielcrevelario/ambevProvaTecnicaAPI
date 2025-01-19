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
    public class ProductReadRepository : IProductReadRepository
    {
        private readonly DefaultContext _context;
        public async Task<List<Product>> GetAllAsync()
        {
            var listProducts = await _context.Products.ToListAsync();
            return listProducts;
        }

        public async Task<Product> GetByIdAsync(Guid id)
        {
            var Product = await _context.Products.FirstOrDefaultAsync(c => c.Id == id);
            return Product;
        }
    }
}
