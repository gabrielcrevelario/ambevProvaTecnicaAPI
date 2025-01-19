using Ambev.DeveloperEvaluation.Application.CartItem.UpdateCartItem;
using Ambev.DeveloperEvaluation.Application.Carts.CreateCart;
using Ambev.DeveloperEvaluation.Application.Users.CreateUser;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Cart.UpdateCart
{
    public class UpdateCartCommand : IRequest<UpdateCartResult>
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public CreateUserCommand Customer { get; set; }
        public string Branch { get; set; }
        public List<UpdateCartItemCommand> Items { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
