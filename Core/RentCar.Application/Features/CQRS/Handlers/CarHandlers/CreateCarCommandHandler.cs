using RentCar.Application.Features.CQRS.Commands.CarCommands;
using RentCar.Application.Interfaces;
using RentCar.Domain.Entities;

namespace RentCar.Application.Features.CQRS.Handlers.CarHandlers
{
    public class CreateCarCommandHandler
    {
        private readonly IRepository<Car> _repository;
        private readonly IRepository<Feature> _featureRepository;

        public CreateCarCommandHandler(IRepository<Car> repository, IRepository<Feature> featureRepository)
        {
            _repository = repository;
            _featureRepository = featureRepository;
        }

        public async Task Handle(CreateCarCommand command)
        {
            Car car = new Car
            {
                BrandId = command.BrandId,
                BigImageUrl = command.BigImageUrl,
                CoverImagerUrl = command.CoverImagerUrl,
                Fuel = command.Fuel,
                Km = command.Km,
                Luggage = command.Luggage,
                Model = command.Model,
                Seat = command.Seat,
                Transmission = command.Transmission,
                CarFeatures = new List<CarFeature>()
            };
            var features = await _featureRepository.GetAllAsync();

            var commonFeatures = features.Where(f => command.CarFeatures.Contains(f.FeatureId)).ToList();

            car.CarFeatures = features.Select(feature => new CarFeature
            {
                CarId = car.CarId,
                FeatureId = feature.FeatureId,
                Available = commonFeatures.Contains(feature)
            }).ToList();

            await _repository.CreateAsync(car);
        }
    }

}

