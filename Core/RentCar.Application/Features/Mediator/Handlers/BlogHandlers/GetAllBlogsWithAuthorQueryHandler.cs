using MediatR;
using RentCar.Application.Features.Mediator.Queries.BlogQueries;
using RentCar.Application.Features.Mediator.Results.BlogResults;
using RentCar.Application.Interfaces.BlogInterfaces;

namespace RentCar.Application.Features.Mediator.Handlers.BlogHandlers
{
    public class GetAllBlogsWithAuthorQueryHandler : IRequestHandler<GetAllBlogsWithAuthorQuery, List<GetAllBlogsWithAuthorQueryResult>>
    {
        private readonly IBlogRepository _repository;

        public GetAllBlogsWithAuthorQueryHandler(IBlogRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetAllBlogsWithAuthorQueryResult>> Handle(GetAllBlogsWithAuthorQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllBlogsWithAuthors();
            return values.Select(x => new GetAllBlogsWithAuthorQueryResult
            {
                AuthorId = x.AuthorId,
                AuthorName = x.Author.Name,
                BlogId = x.BlogId,
                CategoryId = x.CategoryId,
                CategoryName = x.Category.Name,
                CoverImageUrl = x.CoverImageUrl,
                CreatedDate = x.CreatedDate,
                Description = x.Description,
                AuthorDescription = x.Author.Description,
                AuthorImageUrl = x.Author.ImageUrl,
                Title = x.Title
            }).ToList();
        }
    }
}
