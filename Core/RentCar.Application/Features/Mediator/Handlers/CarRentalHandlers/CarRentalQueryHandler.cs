using MediatR;
using RentCar.Application.Features.Mediator.Queries.CarRentalQueries;
using RentCar.Application.Features.Mediator.Results.CarRentalResults;
using RentCar.Application.Interfaces.CarRentalInterfaces;

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
                CarId = x.CarId
            }).ToList();
        }
    }
}
