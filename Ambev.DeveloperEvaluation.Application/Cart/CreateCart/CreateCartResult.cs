using Ambev.DeveloperEvaluation.Application.Carts.CreateCart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Cart.CreateCart
{
    public class CreateCartResult
    {
        public Guid CartId { get; set; }
        public string CartNumber { get; set; }
        public DateTime Date { get; set; }
        public string Customer { get; set; }
        public decimal TotalCartAmount { get; set; }
        public string Branch { get; set; }
        public List<CreateCartItemResult> CreateCartItemResultList { get; set; }
        public bool IsCancelled { get; set; }
    }
}
