using Ambev.DeveloperEvaluation.Application.Carts.CreateCart;
using Ambev.DeveloperEvaluation.Application.Produtct.CreateProduct;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Cart.CreateCart
{
    public class CreateProductValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductValidator()
        {
            RuleFor(x => x.Price)
                .LessThanOrEqualTo(0)
                .WithMessage("Price need Greater than 0.");

            RuleFor(x => x.Title)
                .NotEmpty()
                .WithMessage("Title can't empty");

            RuleFor(x => x.Category)
                .NotEmpty()
                .WithMessage("Category can't empty");

        }

        
    }

}
