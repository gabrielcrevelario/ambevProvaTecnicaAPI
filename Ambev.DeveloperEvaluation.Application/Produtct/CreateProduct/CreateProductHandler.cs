using Ambev.DeveloperEvaluation.Application.Cart.CreateCart;
using Ambev.DeveloperEvaluation.Application.Produtct.CreateProduct;
using Ambev.DeveloperEvaluation.Application.Users.CreateUser;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Product.CreateProduct
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, CreateProductResult>
    {
        private readonly IProductWriteRepository _writeRepository;
        private readonly IMapper _mapper;

        public CreateProductHandler(IProductWriteRepository writeRepository, IMapper mapper)
        {
            _writeRepository = writeRepository;
            _mapper = mapper;
        }

        public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            // Mapear comando para entidade de domínio
            var validator = new CreateProductValidator();
            var validation = await validator.ValidateAsync(command, cancellationToken);
            if (!validation.IsValid)
            {
                var errorMessage = validation.Errors.Select((x) =>
                {
                    return $"error {x.PropertyName} - {x.ErrorMessage}";
                });
                var ErrorMessage = string.Join(',', errorMessage);
                throw new ValidationException(ErrorMessage);
            }

            var Product = _mapper.Map<Domain.Entities.Product>(command);

            // Salvar a venda no banco
            await _writeRepository.AddAsync(Product);

            // Mapear entidade para resultado
            var result = _mapper.Map<CreateProductResult>(Product);

            return result;
        }
    }
}
