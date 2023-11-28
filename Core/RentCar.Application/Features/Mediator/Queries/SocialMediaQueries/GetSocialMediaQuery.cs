using MediatR;
using RentCar.Application.Features.Mediator.Results.SocialMediaResults;

namespace RentCar.Application.Features.Mediator.Queries.SocialMediaQueries
{
    public class GetSocialMediaQuery :IRequest<List<GetSocialMediaQueryResult>>
    {
    }
}
