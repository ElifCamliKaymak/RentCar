using MediatR;
using RentCar.Application.Features.Mediator.Results.TestimonialResults;

namespace RentCar.Application.Features.Mediator.Queries.TestimonialQueries
{
    public class GetTestimonialQuery : IRequest<List<GetTestimonialQueryResult>>
    {
    }
}
