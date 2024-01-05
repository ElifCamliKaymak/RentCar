using RentCar.Application.Features.CQRS.Results.CarResults;
using RentCar.Application.Interfaces.CarInterfaces;

namespace RentCar.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetCarsByBrandIdQueryHandler
    {
        private readonly ICarRepository _repository;

        public GetCarsByBrandIdQueryHandler(ICarRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetCarsByBrandIdQueryResult>> Handle(int id)
        {
            var values = await _repository.GetCarListByBrandId(id);
            return values.Select(x => new GetCarsByBrandIdQueryResult
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
