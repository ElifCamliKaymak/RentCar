using MediatR;
using RentCar.Application.Features.Mediator.Results.BlogResults;

namespace RentCar.Application.Features.Mediator.Queries.BlogQueries
{
    public class GetLastThreeBlogsWithAuthorsQuery : IRequest<List<GetLastThreeBlogsWithAuthorsQueryResult>>
    {
    }
}
