using Ambev.DeveloperEvaluation.Application.Cart.CreateCart;
using Ambev.DeveloperEvaluation.Application.CartItem.UpdateCartItem;
using Ambev.DeveloperEvaluation.Application.Carts.CreateCart;
using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Ambev.DeveloperEvaluation.Application.Cart.UpdateCart
{
    public class UpdateCartProfile : Profile
    {
        public UpdateCartProfile()
        {
            CreateMap<CreateCartCommand, Domain.Entities.Cart>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items));

            CreateMap<UpdateCartItemCommand, Domain.Entities.CartItem>()
                .ForMember(dest => dest.TotalPrice, opt => opt.MapFrom(src => (src.UnitPrice - src.Discount) * src.Quantity));

            CreateMap<Domain.Entities.Cart, UpdateProductResult>()
         .ForMember(dest => dest.CartId, opt => opt.MapFrom(src => src.Id))
         .ForMember(dest => dest.CreateCartItemResultList, opt => opt.MapFrom(src => src.Items));
            CreateMap<Domain.Entities.CartItem, UpdateCartItemResult>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.TotalAmount, opt => opt.MapFrom(src => (src.UnitPrice - src.Discount) * src.Quantity));


            CreateMap<UpdateCartCommand, CreateCartCommand>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items))
                .ForMember(dest => dest.TotalPrice, opt => opt.MapFrom(src => src.TotalPrice))
                // Adicione mais mapeamentos conforme necessário
                .ForMember(dest => dest.Customer, opt => opt.MapFrom(src => src.Customer));
    }

    }
}
