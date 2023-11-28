using MediatR;
using RentCar.Application.Features.Mediator.Queries.SocialMediaQueries;
using RentCar.Application.Features.Mediator.Results.SocialMediaResults;
using RentCar.Application.Interfaces;
using RentCar.Domain.Entities;

namespace RentCar.Application.Features.Mediator.Handlers.SocialMediaHandlers
{
    public class GetSocialMediaQueryHandler : IRequestHandler<GetSocialMediaQuery, List<GetSocialMediaQueryResult>>
    {
        private readonly IRepository<SocialMedia> _repository;

        public GetSocialMediaQueryHandler(IRepository<SocialMedia> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetSocialMediaQueryResult>> Handle(GetSocialMediaQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x=> new GetSocialMediaQueryResult
            {
                Name = x.Name,
                Icon=x.Icon,
                SocialMediaId = x.SocialMediaId,
                Url=x.Url
            }).ToList();
        }
    }
}
