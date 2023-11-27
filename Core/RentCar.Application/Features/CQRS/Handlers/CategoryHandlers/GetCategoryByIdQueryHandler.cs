using RentCar.Application.Features.CQRS.Queries.CategoryQueries;
using RentCar.Application.Features.CQRS.Results.CategoryResults;
using RentCar.Application.Interfaces;
using RentCar.Domain.Entities;

namespace RentCar.Application.Features.CQRS.Handlers.CategoryHandlers
{
    public class GetCategoryByIdQueryHandler
    {
        private readonly IRepository<Category> _repository;

        public GetCategoryByIdQueryHandler(IRepository<Category> repository)
        {
            _repository = repository;
        }

        public async Task<GetCategoryQueryResult> Handle(GetCategoryByIdQuery query)
        {
            var values = await _repository.GetByIdAsync(query.Id);
            return new GetCategoryQueryResult
            {
                CategoryId = values.CategoryId,
                Name = values.Name
            };
        }
    }
}
