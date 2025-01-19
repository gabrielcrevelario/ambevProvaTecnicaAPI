using Ambev.DeveloperEvaluation.Application.Cart.CreateCart;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Cart.GetByIdCart
{
    public class GetByIdCartQuery : IRequest<GetByIdCartResult>
    {
        public Guid Id { get; set; }
    }
}
