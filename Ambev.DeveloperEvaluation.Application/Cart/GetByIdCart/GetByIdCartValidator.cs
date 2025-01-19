using Ambev.DeveloperEvaluation.Application.CartItem.GetByIdCartItem;
using Ambev.DeveloperEvaluation.Application.Users.GetUser;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Cart.GetByIdCart
{
    public class GetByIdCartValidator : AbstractValidator<GetByIdCartQuery>
    {
        public GetByIdCartValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("User ID is required");
        }
    }
}
