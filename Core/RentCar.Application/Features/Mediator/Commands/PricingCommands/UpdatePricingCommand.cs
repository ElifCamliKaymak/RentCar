using MediatR;

namespace RentCar.Application.Features.Mediator.Commands.PricingCommands
{
    public class UpdatePricingCommand :IRequest
    {
        public int PricingId { get; set; }
        public string Name { get; set; }
    }
}
