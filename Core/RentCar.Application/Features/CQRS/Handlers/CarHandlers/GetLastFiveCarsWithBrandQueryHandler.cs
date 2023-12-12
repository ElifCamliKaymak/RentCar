using RentCar.Application.Features.CQRS.Results.CarResults;
using RentCar.Application.Interfaces.CarInterfaces;

namespace RentCar.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetLastFiveCarsWithBrandQueryHandler
    {
        private readonly ICarRepository _repository;

        public GetLastFiveCarsWithBrandQueryHandler(ICarRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetCarWithBrandQueryResult>> Handle()
        {
            var values = await _repository.GetLastFiveCarsWithBrandsAsync();
            return values.Select(x => new GetCarWithBrandQueryResult
            {
                BrandName = x.Brand.Name,
                BrandId = x.BrandId,
                BigImageUrl = x.BigImageUrl,
                CarId = x.CarId,
                CoverImagerUrl = x.CoverImagerUrl,
                Fuel = x.Fuel,
                Km = x.Km,
                Luggage = x.Luggage,
                Model = x.Model,
                Seat = x.Seat,
                Transmission = x.Transmission,
            }).ToList();
        }
    }
}
