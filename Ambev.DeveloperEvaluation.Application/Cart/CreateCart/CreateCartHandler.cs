using Ambev.DeveloperEvaluation.Application.CartItem.CreateCart;
using Ambev.DeveloperEvaluation.Application.CartItem.CreateCartItem;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Cart.CreateCart
{
    public class CreateCartHandler : IRequestHandler<CreateCartCommand, CreateCartResult>
    {
        private readonly ICartWriteRepository _writeRepository;
        private readonly IMapper _mapper;

        public CreateCartHandler(ICartWriteRepository writeRepository, IMapper mapper)
        {
            _writeRepository = writeRepository;
            _mapper = mapper;
        }

        public async Task<CreateCartResult> Handle(CreateCartCommand command, CancellationToken cancellationToken)
        {
            var validatorCart = new CreateCartValidator();
            var validation = await validatorCart.ValidateAsync(command, cancellationToken);
            List<FluentValidation.Results.ValidationResult> validationResultItems = new List<FluentValidation.Results.ValidationResult>();
            foreach (var item in command.Items)
            {
                var validatorÌtem = new CreateCartItemValidator();
                var resultValidationItem = await validatorÌtem.ValidateAsync(item);
                validationResultItems.Add(resultValidationItem);
            }

            if (!validation.IsValid || validationResultItems.Find(x => !x.IsValid) != null)
            {

               var errorMessage= validation.Errors.Select((x) => {
                   return $"error {x.PropertyName} - {x.ErrorMessage}";
               });
                var ErroMessage = string.Join(',',errorMessage);
                throw new System.ComponentModel.DataAnnotations.ValidationException(ErroMessage);
            }

            var cart = _mapper.Map<Domain.Entities.Cart>(command);
            cart.Id = Guid.NewGuid();
            cart.TotalCartAmount = cart.Items.Sum(item => item.TotalPrice);

            // Salvar a venda no banco
            await _writeRepository.AddAsync(cart);

            // Mapear entidade para resultado
            var result = _mapper.Map<CreateCartResult>(cart);

            return result;
        }
    }
}
