using MediatR;
using RentCar.Application.Features.Mediator.Queries.BlogQueries;
using RentCar.Application.Features.Mediator.Results.BlogResults;
using RentCar.Application.Interfaces;
using RentCar.Application.Interfaces.BlogInterfaces;
using RentCar.Domain.Entities;

namespace RentCar.Application.Features.Mediator.Handlers.BlogHandlers
{
    public class GetLastThreeBlogsWithAuthorsQueryHandler : IRequestHandler<GetLastThreeBlogsWithAuthorsQuery, List<GetLastThreeBlogsWithAuthorsQueryResult>>
    {
        private readonly IBlogRepository _blogRepository;

        public GetLastThreeBlogsWithAuthorsQueryHandler(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public async Task<List<GetLastThreeBlogsWithAuthorsQueryResult>> Handle(GetLastThreeBlogsWithAuthorsQuery request, CancellationToken cancellationToken)
        {
            var values = await _blogRepository.GetLastThreeBlogsWithAuthors();
            return values.Select(x => new GetLastThreeBlogsWithAuthorsQueryResult
            {
                AuthorId = x.AuthorId,
                AuthorName= x.Author.Name,
                BlogId = x.BlogId,
                CategoryId = x.CategoryId,
                CoverImageUrl = x.CoverImageUrl,
                CreatedDate = x.CreatedDate,
                Title= x.Title
            }).ToList();
        }
    }
}
