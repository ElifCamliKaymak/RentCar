using MediatR;
using RentCar.Application.Features.Mediator.Results.ServiceResults;

namespace RentCar.Application.Features.Mediator.Queries.ServiceQueries
{
    public class GetServiceQuery : IRequest<List<GetServiceQueryResult>>
    {
    }
}
