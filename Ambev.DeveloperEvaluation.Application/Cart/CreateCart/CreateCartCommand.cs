using Ambev.DeveloperEvaluation.Application.CartItem.CreateCartItem;
using Ambev.DeveloperEvaluation.Application.Users.CreateUser;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Cart.CreateCart
{
    public class CreateCartCommand : IRequest<CreateCartResult>
    {
        public DateTime Date { get; set; }
        public CreateUserCommand Customer { get; set; }
        public string Branch { get; set; }
        public List<CreateCartItemCommand> Items { get; set; }
        public decimal TotalPrice { get; set; }
        
    }
}
