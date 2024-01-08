using MediatR;
using RentCar.Application.Features.Mediator.Queries.BlogQueries;
using RentCar.Application.Features.Mediator.Results.BlogResults;
using RentCar.Application.Interfaces.BlogInterfaces;

namespace RentCar.Application.Features.Mediator.Handlers.BlogHandlers
{
    public class GetBlogsOfCategorysQueryHandler : IRequestHandler<GetBlogsOfCategorysQuery, List<GetBlogsOfCategorysQueryResult>>
    {
        private readonly IBlogRepository _blogRepository;

        public GetBlogsOfCategorysQueryHandler(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public async Task<List<GetBlogsOfCategorysQueryResult>> Handle(GetBlogsOfCategorysQuery request, CancellationToken cancellationToken)
        {
            var values = await _blogRepository.GetBlogsOfCategorys(request.Id);
            return values.Select(x => new GetBlogsOfCategorysQueryResult
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
