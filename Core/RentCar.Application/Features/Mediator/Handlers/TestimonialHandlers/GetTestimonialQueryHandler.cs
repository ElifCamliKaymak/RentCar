using MediatR;
using RentCar.Application.Features.Mediator.Queries.TestimonialQueries;
using RentCar.Application.Features.Mediator.Results.TestimonialResults;
using RentCar.Application.Interfaces;
using RentCar.Domain.Entities;
using System.Windows.Markup;

namespace RentCar.Application.Features.Mediator.Handlers.TestimonialHandlers
{
    public class GetTestimonialQueryHandler : IRequestHandler<GetTestimonialQuery, List<GetTestimonialQueryResult>>
    {
        private readonly IRepository<Testimonial> _repository;

        public GetTestimonialQueryHandler(IRepository<Testimonial> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetTestimonialQueryResult>> Handle(GetTestimonialQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select( x=> new GetTestimonialQueryResult
            {
                TestimonialId=x.TestimonialId,
                Comment = x.Comment,
                ImageUrl = x.ImageUrl,
                Name = x.Name,
                Title = x.Title,
            }).ToList();
        }
    }
}
