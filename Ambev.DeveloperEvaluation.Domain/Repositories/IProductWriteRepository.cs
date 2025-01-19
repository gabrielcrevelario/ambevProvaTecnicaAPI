using Ambev.DeveloperEvaluation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Repositories
{
    public interface IProductWriteRepository
    {
        Task<Product> AddAsync(Product Product);
        Task<Product> UpdateAsync(Guid ProductId, Product Product);
        Task<bool> DeleteAsync(Guid ProductId);

    }
}
