using MediatR;
using RentCar.Application.Features.Mediator.Results.LocationResults;

namespace RentCar.Application.Features.Mediator.Queries.LocationQueries
{
    public class GetLocationQuery : IRequest<List<GetLocationQueryResult>>
    {
    }
}
