using MediatR;
using RentCar.Application.Features.Mediator.Results.CarFeatureResults;

namespace RentCar.Application.Features.Mediator.Queries.GetCarFeatureQueries
{
    public class GetCarDescriptionQuery : IRequest<List<GetCarFeatureByCarIdQueryResult>>
    {
        public int Id { get; set; }

        public GetCarDescriptionQuery(int id)
        {
            Id = id;
        }
    }
}
