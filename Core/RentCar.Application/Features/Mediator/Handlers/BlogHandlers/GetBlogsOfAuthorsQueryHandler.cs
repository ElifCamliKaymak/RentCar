using MediatR;
using RentCar.Application.Features.Mediator.Queries.BlogQueries;
using RentCar.Application.Features.Mediator.Results.BlogResults;
using RentCar.Application.Interfaces.BlogInterfaces;

namespace RentCar.Application.Features.Mediator.Handlers.BlogHandlers
{
    public class GetBlogsOfAuthorsQueryHandler : IRequestHandler<GetBlogsOfAuthorsQuery, List<GetBlogsOfAuthorsQueryResult>>
    {
        private readonly IBlogRepository _blogRepository;

        public GetBlogsOfAuthorsQueryHandler(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }
        public async Task<List<GetBlogsOfAuthorsQueryResult>> Handle(GetBlogsOfAuthorsQuery request, CancellationToken cancellationToken)
        {
            var values = await _blogRepository.GetBlogsOfAuthors(request.Id);
            return values.Select(x => new GetBlogsOfAuthorsQueryResult
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
