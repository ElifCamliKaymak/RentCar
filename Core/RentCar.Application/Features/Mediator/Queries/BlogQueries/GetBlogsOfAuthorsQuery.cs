using MediatR;
using RentCar.Application.Features.Mediator.Results.BlogResults;

namespace RentCar.Application.Features.Mediator.Queries.BlogQueries
{
    public class GetBlogsOfAuthorsQuery :IRequest<List<GetBlogsOfAuthorsQueryResult>>
    {
        public int Id { get; set; }

        public GetBlogsOfAuthorsQuery(int id)
        {
            Id = id;
        }
    }
}
