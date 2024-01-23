using MediatR;
using RentCar.Application.Features.Mediator.Commands.ReservationCommands;
using RentCar.Application.Interfaces;
using RentCar.Domain.Entities;

namespace RentCar.Application.Features.Mediator.Handlers.ReservationHandlers
{
    public class CreateReservationCommandHandler : IRequestHandler<CreateReservationCommand>
    {
        private readonly IRepository<Reservation> _repository;

        public CreateReservationCommandHandler(IRepository<Reservation> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateReservationCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Reservation
            {
                Age = request.Age,
                CarId = request.CarId,
                Description = request.Description,
                DriverLicenceYear = request.DriverLicenceYear,
                DropOffLocationId = request.DropOffLocationId,
                Email = request.Email,
                Name = request.Name,
                PhoneNumber = request.PhoneNumber,
                PickUpLocationId = request.PickUpLocationId,
                Status = Domain.Enums.Status.Added,
                Surname = request.Surname,
            });
        }
    }
}
