using RentCar.Application.Features.CQRS.Results.CarResult;
using RentCar.Application.Interfaces;
using RentCar.Domain.Entities;

namespace RentCar.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetCarQueryHandler
    {
        private readonly IRepository<Car> _repository;

        public GetCarQueryHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetCarQueryResult>> Handle()
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetCarQueryResult
            {
                BrandId = x.BrandId,
                BigImageUrl = x.BigImageUrl,
                CarId   = x.CarId,
                CoverImagerUrl = x.CoverImagerUrl,
                Fuel   = x.Fuel,
                Km=x.Km,
                Luggage = x.Luggage,
                Model = x.Model,
                Seat=x.Seat,
                Transmission=x.Transmission,
            }).ToList();
        }
    }
}
