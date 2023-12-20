using MediatR;
using RentCar.Application.Features.Mediator.Queries.TagCloudQueries;
using RentCar.Application.Features.Mediator.Results.TagCloudResults;
using RentCar.Application.Interfaces;
using RentCar.Domain.Entities;

namespace RentCar.Application.Features.Mediator.Handlers.TagCloudHandlers
{
    public class GetTagCloudQueryHandler : IRequestHandler<GetTagCloudQuery, List<GetTagCloudQueryResult>>
    {
        private readonly IRepository<TagCloud> _repository;

        public GetTagCloudQueryHandler(IRepository<TagCloud> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetTagCloudQueryResult>> Handle(GetTagCloudQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetTagCloudQueryResult
            {
                BlogId = x.BlogId,
                TagCloudId = x.TagCloudId,
                Title = x.Title
            }).ToList();
        }
    }
}
