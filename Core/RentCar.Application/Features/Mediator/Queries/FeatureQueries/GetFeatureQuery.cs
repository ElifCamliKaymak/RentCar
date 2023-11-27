using MediatR;
using RentCar.Application.Features.Mediator.Results.FeatureResults;

namespace RentCar.Application.Features.Mediator.Queries.FeatureQueries
{
    public class GetFeatureQuery : IRequest<List<GetFeatureQueryResult>>
    {

    }
}
