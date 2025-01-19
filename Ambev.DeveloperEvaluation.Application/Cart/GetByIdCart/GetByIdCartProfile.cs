using Ambev.DeveloperEvaluation.Application.CartItem.GetByIdCartItem;
using Ambev.DeveloperEvaluation.Application.Users.CreateUser;
using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Cart.GetByIdCart
{
    public class GetByIdProfile : Profile
    {
        /// <summary>
        /// Initializes the mappings for CreateUser operation
        /// </summary>
        public GetByIdProfile()
        {
            CreateMap<GetByIdCartQuery, Domain.Entities.Cart>();
            CreateMap<Domain.Entities.Cart, GetByIdCartResult>();
        }
    }
}
