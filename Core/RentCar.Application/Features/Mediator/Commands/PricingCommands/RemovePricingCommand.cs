using MediatR;

namespace RentCar.Application.Features.Mediator.Commands.PricingCommands
{
    public class RemovePricingCommand : IRequest
    {
        public int Id { get; set; }

        public RemovePricingCommand(int id)
        {
            Id = id;
        }
    }
}
