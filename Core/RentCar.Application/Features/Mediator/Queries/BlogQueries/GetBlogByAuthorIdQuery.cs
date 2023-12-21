using MediatR;
using RentCar.Application.Features.Mediator.Results.BlogResults;

namespace RentCar.Application.Features.Mediator.Queries.BlogQueries
{
    public class GetBlogByAuthorIdQuery : IRequest<List<GetBlogByAuthorIdQueryResult>>
    {
        public int Id { get; set; }

        public GetBlogByAuthorIdQuery(int id)
        {
            Id = id;
        }
    }
}
