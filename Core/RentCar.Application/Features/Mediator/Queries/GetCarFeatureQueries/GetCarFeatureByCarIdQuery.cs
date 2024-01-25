using MediatR;
using RentCar.Application.Features.Mediator.Results.CarFeatureResults;

namespace RentCar.Application.Features.Mediator.Queries.GetCarFeatureQueries
{
    public class GetCarFeatureByCarIdQuery : IRequest<List<GetCarFeatureByCarIdQueryResult>>
    {
        public int Id { get; set; }

        public GetCarFeatureByCarIdQuery(int id)
        {
            Id = id;
        }
    }
}
