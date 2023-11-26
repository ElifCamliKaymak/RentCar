using RentCar.Application.Features.CQRS.Commands.BrandCommands;
using RentCar.Application.Interfaces;
using RentCar.Domain.Entities;

namespace RentCar.Application.Features.CQRS.Handlers.BrandHandlers
{
    public class UpdateBrandCommandHandler
    {
        private readonly IRepository<Brand> _repository;

        public UpdateBrandCommandHandler(IRepository<Brand> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateBrandCommand command)
        {
            var values = await _repository.GetByIdAsync(command.BrandId);
            values.Name = command.Name;
            await _repository.UpdateAsync(values);
        }
    }
}
