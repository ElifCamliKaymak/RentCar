using MediatR;
using RentCar.Application.Features.Mediator.Queries.ServiceQueries;
using RentCar.Application.Features.Mediator.Results.ServiceResults;
using RentCar.Application.Interfaces;
using RentCar.Domain.Entities;

namespace RentCar.Application.Features.Mediator.Handlers.ServiceHandlers
{
    public class GetServiceQueryHandler : IRequestHandler<GetServiceQuery, List<GetServiceQueryResult>>
    {
        private readonly IRepository<Service> _repository;

        public GetServiceQueryHandler(IRepository<Service> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetServiceQueryResult>> Handle(GetServiceQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x=> new GetServiceQueryResult
            {
                Description = x.Description,
                IconUrl = x.IconUrl,
                ServiceId = x.ServiceId,
                Title= x.Title
            }).ToList();
        }
    }
}
