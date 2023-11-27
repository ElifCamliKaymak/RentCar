using MediatR;
using RentCar.Application.Features.Mediator.Commands.FooterAddressCommands;
using RentCar.Application.Interfaces;
using RentCar.Domain.Entities;

namespace RentCar.Application.Features.Mediator.Handlers.FooterAddressHandlers
{
    public class UpdateFooterAddressCommandHandler : IRequestHandler<UpdateFooterAddressCommand>
    {
        private readonly IRepository<FooterAddress> _repository;

        public UpdateFooterAddressCommandHandler(IRepository<FooterAddress> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateFooterAddressCommand request, CancellationToken cancellationToken)
        {
            var value=await _repository.GetByIdAsync(request.FooterAddressId);
            value.Address = request.Address;
            value.Description = request.Description;
            value.PhoneNumber = request.PhoneNumber;
            value.Email = request.Email;
            await _repository.UpdateAsync(value);
        }
    }
}
