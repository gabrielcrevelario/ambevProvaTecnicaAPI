using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.CartItem.CreateCartItem
{
    public class CreateCartItemValidator : AbstractValidator<CreateCartItemCommand>
    {
        public CreateCartItemValidator()
        {
            RuleFor(x => x.Product)
                .NotEmpty()
                .WithMessage("Product is required.");

            RuleFor(x => x.Quantity)
                .GreaterThan(0)
                .WithMessage("Quantity must be greater than zero.")
                .LessThanOrEqualTo(20)
                .WithMessage("Quantity cannot exceed 20 items.");

            RuleFor(x => x.UnitPrice)
                .GreaterThan(0)
                .WithMessage("Unit price must be greater than zero.");

            RuleFor(x => x)
                .Must(IsValidDiscount)
                .WithMessage("Invalid discount for the given quantity.");
        }


        private bool IsValidDiscount(CreateCartItemCommand item)
        {
            // Regras para o desconto baseado na quantidade
            if (item.Quantity < 4)
            {
                // Nenhum desconto permitido para menos de 4 itens
                return item.Discount == 0;
            }
            else if (item.Quantity >= 4 && item.Quantity < 10)
            {
                // 10% de desconto permitido para 4-9 itens
                var expectedDiscount = item.UnitPrice * 0.10m * item.Quantity;
                return item.Discount == expectedDiscount;
            }
            else if (item.Quantity >= 10 && item.Quantity <= 20)
            {
                // 20% de desconto permitido para 10-20 itens
                var expectedDiscount = item.UnitPrice * 0.20m * item.Quantity;
                return item.Discount == expectedDiscount;
            }

            // Caso contrário, invalida qualquer desconto
            return false;
        }
    }

}
