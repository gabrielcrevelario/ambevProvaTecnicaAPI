using Ambev.DeveloperEvaluation.Application.Cart.GetByIdCart;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Product.CreateProduct
{
    public class GetByIdCartHandler : IRequestHandler<GetByIdCartQuery, GetByIdCartResult>
    {
        private readonly ICartReadRepository _readRepository;
        private readonly IMapper _mapper;

        public GetByIdCartHandler(ICartReadRepository readRepository, IMapper mapper)
        {
            _readRepository = readRepository;
            this._mapper = mapper;
        }

        public async Task<GetByIdCartResult> Handle(GetByIdCartQuery query, CancellationToken cancellationToken)
        {
            var validator = new GetByIdCartValidator();
            var validation = await validator.ValidateAsync(query, cancellationToken);    
            if (!validation.IsValid)
                throw new KeyNotFoundException($"Cart with ID {query.Id} not found");
            var cart = await _readRepository.GetByIdAsync(query.Id);
            var result = _mapper.Map<GetByIdCartResult>(cart);

            return result;
        }
    }
}
