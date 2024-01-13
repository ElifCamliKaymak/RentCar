using MediatR;
using RentCar.Application.Features.Mediator.Queries.StatisticQueries;
using RentCar.Application.Features.Mediator.Results.StatisticResults;
using RentCar.Application.Interfaces.StatisticInterfaces;

namespace RentCar.Application.Features.Mediator.Handlers.StatisticHandlers
{
    public class GetBrandNameByMaximumCarQueryHandler : IRequestHandler<GetBrandNameByMaximumCarQuery, GetBrandNameByMaximumCarQueryResult>
    {
        private readonly IStatisticRepository _repository;

        public GetBrandNameByMaximumCarQueryHandler(IStatisticRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetBrandNameByMaximumCarQueryResult> Handle(GetBrandNameByMaximumCarQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetBrandNameByMaximumCar();
            return new GetBrandNameByMaximumCarQueryResult
            {
                BrandNameByMaximumCar = value
            };
        }
    }
}
