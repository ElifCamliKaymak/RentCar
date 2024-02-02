using MediatR;
using RentCar.Application.Features.Mediator.Commands.AppUserCommands;
using RentCar.Application.Interfaces;
using RentCar.Domain.Entities;
using RentCar.Domain.Enums;

namespace RentCar.Application.Features.Mediator.Handlers.AppUserHandlers
{
    public class CreateAppUserCommandHandler : IRequestHandler<CreateAppUserCommand>
    {
        private readonly IRepository<AppUser> _repository;

        public CreateAppUserCommandHandler(IRepository<AppUser> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateAppUserCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new AppUser
            {
                UserName = request.UserName,
                Password = request.Password,
                AppRoleId = (int)Role.Member,
            });
        }
    }
}
