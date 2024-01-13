using MediatR;
using RentCar.Application.Features.Mediator.Queries.StatisticQueries;
using RentCar.Application.Features.Mediator.Results.StatisticResults;
using RentCar.Application.Interfaces.StatisticInterfaces;

namespace RentCar.Application.Features.Mediator.Handlers.StatisticHandlers
{
    public class GetAverageRentPriceForDailyQueryHandler : IRequestHandler<GetAverageRentPriceForDailyQuery, GetAverageRentPriceForDailyQueryResult>
    {
        private readonly IStatisticRepository _repository;

        public GetAverageRentPriceForDailyQueryHandler(IStatisticRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetAverageRentPriceForDailyQueryResult> Handle(GetAverageRentPriceForDailyQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetAverageRentPriceForDaily();
            return new GetAverageRentPriceForDailyQueryResult
            {
                AveragePriceForDaily = value
            };
        }
    }
}
