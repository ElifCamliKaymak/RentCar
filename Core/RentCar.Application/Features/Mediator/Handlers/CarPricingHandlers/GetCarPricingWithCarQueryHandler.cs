using MediatR;
using RentCar.Application.Features.Mediator.Queries.CarPricingQueries;
using RentCar.Application.Features.Mediator.Results.CarPricingResults;
using RentCar.Application.Interfaces.CarPricingInterfaces;

namespace RentCar.Application.Features.Mediator.Handlers.CarPricingHandlers
{
    public class GetCarPricingWithCarQueryHandler : IRequestHandler<GetCarPricingWithCarQuery, List<GetCarPricingWithCarQueryResult>>
    {
        private readonly ICarPricingRepository _repository;

        public GetCarPricingWithCarQueryHandler(ICarPricingRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetCarPricingWithCarQueryResult>> Handle(GetCarPricingWithCarQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetCarPricingWithCars();
            return values.Select(x => new GetCarPricingWithCarQueryResult
            {
                Amount = x.Amount,
                BrandName = x.Car.Brand.Name,
                CarPricingId = x.CarPricingId,
                CoverImageUrl = x.Car.CoverImagerUrl,
                Model = x.Car.Model
            }).ToList();
        }
    }
}
