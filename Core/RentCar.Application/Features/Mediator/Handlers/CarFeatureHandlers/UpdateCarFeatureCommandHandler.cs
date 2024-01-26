using MediatR;
using RentCar.Application.Features.Mediator.Commands.CarFeatureCommands;
using RentCar.Application.Interfaces;
using RentCar.Domain.Entities;

namespace RentCar.Application.Features.Mediator.Handlers.CarFeatureHandlers
{
    public class UpdateCarFeatureCommandHandler : IRequestHandler<UpdateCarFeatureCommand>
    {
        private readonly IRepository<CarFeature> _repository;

        public UpdateCarFeatureCommandHandler(IRepository<CarFeature> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateCarFeatureCommand request, CancellationToken cancellationToken)
        {
            var value =await _repository.GetByIdAsync(request.CarFeatureId);
            value.FeatureId = request.FeatureId;
            value.Available = request.Available;
            value.CarId = request.CarId;
            await _repository.UpdateAsync(value);
        }
    }
}
