using MediatR;
using RentCar.Application.Features.Mediator.Queries.StatisticQueries;
using RentCar.Application.Features.Mediator.Results.StatisticResults;
using RentCar.Application.Interfaces.StatisticInterfaces;

namespace RentCar.Application.Features.Mediator.Handlers.StatisticHandlers
{
    public class GetAverageRentPriceForWeeklyQueryHandler : IRequestHandler<GetAverageRentPriceForWeeklyQuery, GetAverageRentPriceForWeeklyQueryResult>
    {
        private readonly IStatisticRepository _repository;

        public GetAverageRentPriceForWeeklyQueryHandler(IStatisticRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetAverageRentPriceForWeeklyQueryResult> Handle(GetAverageRentPriceForWeeklyQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetAverageRentPriceForWeekly();
            return new GetAverageRentPriceForWeeklyQueryResult
            {
                AveragePriceForWeekly = value
            };
        }
    }
}
