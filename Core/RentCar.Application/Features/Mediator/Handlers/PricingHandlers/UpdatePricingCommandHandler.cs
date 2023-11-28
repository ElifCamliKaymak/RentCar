using MediatR;
using RentCar.Application.Features.Mediator.Commands.PricingCommands;
using RentCar.Application.Interfaces;
using RentCar.Domain.Entities;

namespace RentCar.Application.Features.Mediator.Handlers.PricingHandlers
{
    public class UpdatePricingCommandHandler : IRequestHandler<UpdatePricingCommand>
    {
        private readonly IRepository<Pricing> _repository;

        public UpdatePricingCommandHandler(IRepository<Pricing> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdatePricingCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.PricingId);
            value.Name = request.Name;
            await _repository.UpdateAsync(value);
        }
    }
}
