using Ambev.DeveloperEvaluation.Application.Cart.CreateCart;
using Ambev.DeveloperEvaluation.Application.Carts.CreateCart;
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
            CreateMap<CreateCartCommand, Domain.Entities.Cart>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items));

            CreateMap<CreatealeItemDTO, CartItem>()
                .ForMember(dest => dest.TotalAmount, opt => opt.MapFrom(src => (src.UnitPrice - src.Discount) * src.Quantity));

            CreateMap<Domain.Entities.Cart, UpdateProductResult>()
         .ForMember(dest => dest.CartId, opt => opt.MapFrom(src => src.Id))
         .ForMember(dest => dest.CreateCartItemResultList, opt => opt.MapFrom(src => src.Items));
            CreateMap<CartItem, CreateCartItemResult>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.TotalAmount, opt => opt.MapFrom(src => (src.UnitPrice - src.Discount) * src.Quantity));
        }
    }
}
