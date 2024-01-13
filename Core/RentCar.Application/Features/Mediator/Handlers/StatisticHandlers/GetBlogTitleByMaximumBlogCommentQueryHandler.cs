using MediatR;
using RentCar.Application.Features.Mediator.Queries.StatisticQueries;
using RentCar.Application.Features.Mediator.Results.StatisticResults;
using RentCar.Application.Interfaces.StatisticInterfaces;

namespace RentCar.Application.Features.Mediator.Handlers.StatisticHandlers
{
    public class GetBlogTitleByMaximumBlogCommentQueryHandler : IRequestHandler<GetBlogTitleByMaximumBlogCommentQuery, GetBlogTitleByMaximumBlogCommentQueryResult>
    {
        private readonly IStatisticRepository _repository;

        public GetBlogTitleByMaximumBlogCommentQueryHandler(IStatisticRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetBlogTitleByMaximumBlogCommentQueryResult> Handle(GetBlogTitleByMaximumBlogCommentQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetBlogTitleByMaximumBlogComment();
            return new GetBlogTitleByMaximumBlogCommentQueryResult
            {
                BlogTitleByMaximumBlogComment = value
            };
        }
    }
}
