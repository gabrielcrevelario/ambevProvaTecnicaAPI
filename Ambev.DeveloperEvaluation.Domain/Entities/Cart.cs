using Ambev.DeveloperEvaluation.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class Cart : BaseEntity
    {
        public DateTime Date { get; set; }
        public string Customer { get; set; } = string.Empty;
        public decimal TotalCartAmount { get; set; }
        public string Branch { get; set; } = string.Empty;
        public List<CartItem> Items { get; set; }
        public bool IsCancelled { get; set; }
    }
}
