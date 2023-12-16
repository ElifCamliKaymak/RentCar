using MediatR;
using RentCar.Application.Features.Mediator.Results.AuthorResults;

namespace RentCar.Application.Features.Mediator.Queries.AuthorQueries
{
    public class GetAuthorQuery :IRequest<List<GetAuthorQueryResult>>
    {
    }
}
