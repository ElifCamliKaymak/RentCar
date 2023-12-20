using MediatR;
using RentCar.Application.Features.Mediator.Results.TagCloudResults;

namespace RentCar.Application.Features.Mediator.Queries.TagCloudQueries
{
    public class GetTagCloudQuery : IRequest<List<GetTagCloudQueryResult>>
    {
    }
}
