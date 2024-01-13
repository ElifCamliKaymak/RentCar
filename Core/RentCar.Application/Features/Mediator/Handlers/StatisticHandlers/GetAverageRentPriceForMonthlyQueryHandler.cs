using MediatR;
using RentCar.Application.Features.Mediator.Queries.StatisticQueries;
using RentCar.Application.Features.Mediator.Results.StatisticResults;
using RentCar.Application.Interfaces.StatisticInterfaces;

namespace RentCar.Application.Features.Mediator.Handlers.StatisticHandlers
{
    public class GetAverageRentPriceForMonthlyQueryHandler : IRequestHandler<GetAverageRentPriceForMonthlyQuery, GetAverageRentPriceForMonthlyQueryResult>
    {
        private readonly IStatisticRepository _repository;

        public GetAverageRentPriceForMonthlyQueryHandler(IStatisticRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetAverageRentPriceForMonthlyQueryResult> Handle(GetAverageRentPriceForMonthlyQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetAverageRentPriceForMonthly();
            return new GetAverageRentPriceForMonthlyQueryResult
            {
                AveragePriceForMonthly = value
            };
        }
    }
}
