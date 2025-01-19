using Ambev.DeveloperEvaluation.Application.Cart.CreateCart;
using Ambev.DeveloperEvaluation.Application.Cart.UpdateCart;
using Ambev.DeveloperEvaluation.Application.CartItem.CreateCartItem;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.CartItem.CreateCart
{
    public class CreateCartValidator : AbstractValidator<CreateCartCommand>
    {
        public CreateCartValidator()
        {
            RuleFor(x => x.Items)
                .NotEmpty()
                .WithMessage("Your cart need at least one Item");
            RuleForEach(x => x.Items).ChildRules(async cartItem =>
            {
                var validator = new CreateCartItemValidator();
                cartItem.RuleFor(x => x.Quantity).Must((x, quantity) => ApplyDiscountLogic(x.UnitPrice, x.Discount, quantity))
                 .WithMessage("The total Price in item isn't correct with the application discount.");
            });

            RuleFor(x => x.TotalPrice)
                .GreaterThan(0)
                .WithMessage("TotalPrice must be greater than zero.");

            RuleFor(x => x.Customer)
                .NotEmpty()
                .WithMessage("You Need customer vinculated in the sale");

        }
        private bool ApplyDiscountLogic(decimal price, decimal discount, int quantity)
        {
            decimal finalPrice = price - discount;
            decimal expectedPrice = finalPrice * quantity;

            if (quantity >= 4 && quantity <= 20)
            {
                // Exemplo de desconto de 10% a 20%
                decimal discountRate = quantity >= 10 ? 0.2M : 0.1M;
                decimal discountedTotal = finalPrice * (1 - discountRate) * quantity;
                return discountedTotal >= 0;
            }

            return true; // Caso não haja condição especial de desconto
        }

    }

}
