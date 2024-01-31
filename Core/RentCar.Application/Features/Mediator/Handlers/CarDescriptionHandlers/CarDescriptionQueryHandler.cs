using MediatR;
using RentCar.Application.Features.Mediator.Queries.CarDescriptionQueries;
using RentCar.Application.Features.Mediator.Results.CarDescriptionResult;
using RentCar.Application.Interfaces.CarDescriptionInterfaces;

namespace RentCar.Application.Features.Mediator.Handlers.CarDescriptionHandlers
{
    public class CarDescriptionQueryHandler : IRequestHandler<GetCarDescriptionByCarIdQuery, List<GetCarDescriptionQueryResult>>
    {
        private readonly ICarDescriptionRepository _repository;

        public CarDescriptionQueryHandler(ICarDescriptionRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetCarDescriptionQueryResult>> Handle(GetCarDescriptionByCarIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetCarDescriptionAsync(request.Id);
            return values.Select(x => new GetCarDescriptionQueryResult
            {
                CarDescriptionId = x.CarDescriptionId,
                CarId = x.CarId,
                Details = x.Details
            }).ToList();
        }
    }
}
