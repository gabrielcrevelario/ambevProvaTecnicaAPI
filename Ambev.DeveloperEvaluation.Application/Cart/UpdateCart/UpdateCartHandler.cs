using Ambev.DeveloperEvaluation.Application.Cart.CreateCart;
using Ambev.DeveloperEvaluation.Application.CartItem.CreateCart;
using Ambev.DeveloperEvaluation.Application.CartItem.CreateCartItem;
using Ambev.DeveloperEvaluation.Application.Users.CreateUser;
using Ambev.DeveloperEvaluation.Common.Security;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;
using OneOf.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Cart.UpdateCart
{
    public class UpdateCartHandler : IRequestHandler<UpdateCartCommand, UpdateCartResult>
    {
        private readonly ICartWriteRepository _writeRepository;
        private readonly ICartReadRepository _readRepository;
        private readonly IMapper _mapper;
        public UpdateCartHandler(ICartWriteRepository writeRepository, ICartReadRepository readRepository, IEventPublisher eventPublisher, IMapper mapper)
        {
            _writeRepository = writeRepository;
            _readRepository = readRepository;
            //_eventPublisher = eventPublisher;
            this._mapper = mapper;
        }

        public async Task<UpdateCartResult> Handle(UpdateCartCommand command, CancellationToken cancellationToken)
        {
            // Recupera a venda existente
            var validatorDefault = new CreateCartValidator();
            var validatorItem = new CreateCartItemValidator();

            CreateCartCommand createCartCommand = _mapper.Map<CreateCartCommand>(command);
            var validationCreate = await validatorDefault.ValidateAsync(createCartCommand, cancellationToken);
            List<FluentValidation.Results.ValidationResult> validationResultItems = new List<FluentValidation.Results.ValidationResult>();
            foreach (var item in createCartCommand.Items)
            {
                var validatorÌtem = new CreateCartItemValidator();
                var result = await validatorÌtem.ValidateAsync(item);
                validationResultItems.Add(result);
            }
            if (!validationCreate.IsValid || validationResultItems.Find(x => !x.IsValid) != null)
            {
                var errorMessage = validationCreate.Errors.Select((x) =>
                {
                    return $"error {x.PropertyName} - {x.ErrorMessage}";
                });
            var ErroMessage = string.Join(',', errorMessage);
            throw new System.ComponentModel.DataAnnotations.ValidationException(ErroMessage);
            }

            var cart = _mapper.Map<Domain.Entities.Cart>(command);

            var updatedCart = await _writeRepository.UpdateAsync(command., cart);
            var resultUpdate = _mapper.Map<UpdateCartResult>(updatedCart);
            return resultUpdate;
        }
    }

}
