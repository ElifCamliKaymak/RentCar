using MediatR;
using RentCar.Application.Features.Mediator.Results.StatisticResults;

namespace RentCar.Application.Features.Mediator.Queries.StatisticQueries
{
    public class GetAverageRentPriceForDailyQuery : IRequest<GetAverageRentPriceForDailyQueryResult>
    {
    }
}
