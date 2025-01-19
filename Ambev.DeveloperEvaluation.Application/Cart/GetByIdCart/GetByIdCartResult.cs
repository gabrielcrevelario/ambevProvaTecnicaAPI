using Ambev.DeveloperEvaluation.Application.CartItem.GetByIdCartItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Cart.GetByIdCart
{
    public class GetByIdCartResult
    {
        public Guid CartId { get; set; }
        public string CartNumber { get; set; }
        public DateTime Date { get; set; }
        public string Customer { get; set; }
        public decimal TotalCartAmount { get; set; }
        public string Branch { get; set; }
        public List<GetByIdCartItemResult> GetByIdCartItemResultList { get; set; }
        public bool IsCancelled { get; set; }
    }
}
