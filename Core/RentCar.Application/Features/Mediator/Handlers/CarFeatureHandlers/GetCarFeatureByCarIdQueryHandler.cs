using MediatR;
using RentCar.Application.Features.Mediator.Queries.GetCarFeatureQueries;
using RentCar.Application.Features.Mediator.Results.CarFeatureResults;
using RentCar.Application.Interfaces.CarFeatureInterfaces;

namespace RentCar.Application.Features.Mediator.Handlers.CarFeatureHandlers
{
    public class GetCarFeatureByCarIdQueryHandler : IRequestHandler<GetCarFeatureByCarIdQuery, List<GetCarFeatureByCarIdQueryResult>>
    {
        private readonly ICarFeatureRepository _repository;

        public GetCarFeatureByCarIdQueryHandler(ICarFeatureRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetCarFeatureByCarIdQueryResult>> Handle(GetCarFeatureByCarIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetCarFeaturesByCarId(request.Id);
            return values.Select(x => new GetCarFeatureByCarIdQueryResult
            {
                Available = x.Available,
                CarFeatureId = x.CarFeatureId,
                FeatureId = x.FeatureId,
                FeatureName = x.Feature.Name,
                CarId = x.CarId,
            }).ToList();
        }
    }
}
