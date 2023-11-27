using RentCar.Application.Features.CQRS.Queries.ContactQueries;
using RentCar.Application.Features.CQRS.Results.ContactResults;
using RentCar.Application.Interfaces;
using RentCar.Domain.Entities;

namespace RentCar.Application.Features.CQRS.Handlers.ContactHandlers
{
    public class GetContactByIdQueryHandler
    {
        private readonly IRepository<Contact> _repository;

        public GetContactByIdQueryHandler(IRepository<Contact> repository)
        {
            _repository = repository;
        }

        public async Task<GetContactQueryResult> Handle(GetContactByIdQuery query)
        {
            var values = await _repository.GetByIdAsync(query.Id);
            return new GetContactQueryResult
            {
                ContactId = values.ContactId,
                Name = values.Name,
                Email = values.Email,
                Subject = values.Subject,
                Message = values.Message,
                SendDate = values.SendDate,
            };
        }
    }
}
