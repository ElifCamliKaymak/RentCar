using MediatR;

namespace RentCar.Application.Features.Mediator.Commands.CarFeatureCommands
{
    public class UpdateCarFeatureCommand : IRequest
    {
        public int CarFeatureId { get; set; }
        public int CarId { get; set; }
        public int FeatureId { get; set; }
        public bool Available { get; set; }
    }
}
