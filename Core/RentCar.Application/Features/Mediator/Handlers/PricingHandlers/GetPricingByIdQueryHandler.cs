using MediatR;
using RentCar.Application.Features.Mediator.Queries.PricingQueries;
using RentCar.Application.Features.Mediator.Results.PricingResults;
using RentCar.Application.Interfaces;
using RentCar.Domain.Entities;

namespace RentCar.Application.Features.Mediator.Handlers.PricingHandlers
{
    public class GetPricingByIdQueryHandler : IRequestHandler<GetPricingByIdQuery, GetPricingByIdQueryResult>
    {
        private readonly IRepository<Pricing> _repository;

        public GetPricingByIdQueryHandler(IRepository<Pricing> repository)
        {
            _repository = repository;
        }

        public async Task<GetPricingByIdQueryResult> Handle(GetPricingByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            return new GetPricingByIdQueryResult
            {
                Name = value.Name,
                PricingId=value.PricingId
            };
        }
    }
}
