using Ambev.DeveloperEvaluation.Application.CartItem.UpdateCartItem;
using Ambev.DeveloperEvaluation.Application.Carts.CreateCart;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Cart.UpdateCart
{
    public class UpdateCartValidator : AbstractValidator<UpdateCartCommand>
    {
        public UpdateCartValidator()
        {

            RuleFor(cart => cart.Items)
              .Must(items => items.Count > 0).WithMessage("The cart must have at least one item to be updated.\r\n");
        }

    }

}
