using RentCar.Application.Features.CQRS.Commands.AboutCommands;
using RentCar.Application.Interfaces;
using RentCar.Domain.Entities;

namespace RentCar.Application.Features.CQRS.Handlers.AboutHandlers
{
    public class UpdateAboutCommandHandle
    {
        private readonly IRepository<About> _repository;

        public UpdateAboutCommandHandle(IRepository<About> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateAboutCommand command)
        {
            var values = await _repository.GetByIdAsync(command.AboutId);
            values.Description = command.Description;
            values.Title = command.Title;
            values.ImageUrl = command.ImageUrl;
            await _repository.UpdateAsync(values);
        }
    }
}
