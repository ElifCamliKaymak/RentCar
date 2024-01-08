using MediatR;
using RentCar.Application.Features.Mediator.Results.BlogResults;

namespace RentCar.Application.Features.Mediator.Queries.BlogQueries
{
    public class GetBlogsOfCategorysQuery : IRequest<List<GetBlogsOfCategorysQueryResult>>
    {
        public int Id { get; set; }

        public GetBlogsOfCategorysQuery(int id)
        {
            Id = id;
        }
    }
}
