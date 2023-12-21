using MediatR;
using RentCar.Application.Features.Mediator.Queries.BlogQueries;
using RentCar.Application.Features.Mediator.Results.BlogResults;
using RentCar.Application.Interfaces.BlogInterfaces;

namespace RentCar.Application.Features.Mediator.Handlers.BlogHandlers
{
    public class GetBlogByAuthorIdQueryHandler : IRequestHandler<GetBlogByAuthorIdQuery, List<GetBlogByAuthorIdQueryResult>>
    {
        private readonly IBlogRepository _blogRepository;

        public GetBlogByAuthorIdQueryHandler(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public async Task<List<GetBlogByAuthorIdQueryResult>> Handle(GetBlogByAuthorIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _blogRepository.GetBlogByAuthorIdAsync(request.Id);
            return values.Select(x => new GetBlogByAuthorIdQueryResult
            {
                AuthorDescription = x.Description,
                AuthorId = x.AuthorId,
                AuthorImageUrl = x.Author.ImageUrl,
                AuthorName = x.Author.Name,
                BlogId = x.BlogId
            }).ToList();
        }
    }
}
