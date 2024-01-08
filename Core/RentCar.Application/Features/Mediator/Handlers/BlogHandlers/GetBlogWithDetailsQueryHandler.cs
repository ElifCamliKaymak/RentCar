using MediatR;
using RentCar.Application.Features.Mediator.Queries.BlogQueries;
using RentCar.Application.Features.Mediator.Results.BlogResults;
using RentCar.Application.Interfaces.BlogInterfaces;

namespace RentCar.Application.Features.Mediator.Handlers.BlogHandlers
{
    public class GetBlogWithDetailsQueryHandler : IRequestHandler<GetBlogWithDetailsQuery, List<GetBlogWithDetailsQueryResult>>
    {
        private readonly IBlogRepository _blogRepository;

        public GetBlogWithDetailsQueryHandler(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public async Task<List<GetBlogWithDetailsQueryResult>> Handle(GetBlogWithDetailsQuery request, CancellationToken cancellationToken)
        {
            var values = await _blogRepository.GetBlogWithDetails(request.Id);
            return values.Select(x => new GetBlogWithDetailsQueryResult
            {
                AuthorName = x.Author.Name,
                BlogId = x.BlogId,
                CategoryName = x.Category.Name,
                CoverImageUrl = x.CoverImageUrl,
                CreatedDate = x.CreatedDate,
                Description = x.Description,
                Title = x.Title,
            }).ToList();
        }
    }
}
