using MediatR;
using RentCar.Application.Features.Mediator.Results.BlogResults;

namespace RentCar.Application.Features.Mediator.Queries.BlogQueries
{
    public class GetBlogWithDetailsQuery : IRequest<List<GetBlogWithDetailsQueryResult>>
    {
        public int Id { get; set; }

        public GetBlogWithDetailsQuery(int id)
        {
            Id = id;
        }
    }
}
