using MediatR;
using RentCar.Application.Features.Mediator.Results.CarRentalResults;

namespace RentCar.Application.Features.Mediator.Queries.CarRentalQueries
{
    public class GetCarRentalQuery : IRequest<List<GetCarRentalQueryResult>>
    {
        public int LocationId { get; set; }
        public bool IsAvailable { get; set; }
    }
}
