using MediatR;
using RentCar.Application.Features.Mediator.Queries.CarRentalQueries;
using RentCar.Application.Features.Mediator.Results.CarRentalResults;
using RentCar.Application.Interfaces.CarRentalInterfaces;
using RentCar.Domain.Entities;

namespace RentCar.Application.Features.Mediator.Handlers.CarRentalHandlers
{
    public class CarRentalQueryHandler : IRequestHandler<GetCarRentalQuery, List<GetCarRentalQueryResult>>
    {
        private readonly ICarRentalRepository _repository;

        public CarRentalQueryHandler(ICarRentalRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetCarRentalQueryResult>> Handle(GetCarRentalQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByFilterAsync(x => x.LocationId == request.LocationId && x.IsAvailable == true);
            return values.Select(x => new GetCarRentalQueryResult
            {
                CarId = x.CarId,
                BrandName = x.Car.Brand.Name,
                CoverImageUrl = x.Car.CoverImagerUrl,
                Model = x.Car.Model,
                Amount = x.Car.CarPricings
                    .FirstOrDefault(cp => cp.Pricing.Name == "Günlük")?.Amount ?? 0
            }).ToList();
        }
    }
}
