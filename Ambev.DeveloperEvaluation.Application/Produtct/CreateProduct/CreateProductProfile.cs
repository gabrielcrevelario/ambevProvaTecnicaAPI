using Ambev.DeveloperEvaluation.Application.Cart.CreateCart;
using Ambev.DeveloperEvaluation.Application.CartItem.CreateCartItem;
using Ambev.DeveloperEvaluation.Application.Produtct.CreateProduct;
using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Ambev.DeveloperEvaluation.Application.Carts.CreateCart
{
    public class CreateProductProfile : Profile
    {
        public CreateProductProfile()
        {
            CreateMap<CreateProductCommand, Domain.Entities.Product>();
            CreateMap<Domain.Entities.Cart, CreateProductResult>();
        }
    }
}
