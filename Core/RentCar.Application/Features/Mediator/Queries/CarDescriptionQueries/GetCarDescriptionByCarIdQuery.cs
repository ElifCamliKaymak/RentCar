using MediatR;
using RentCar.Application.Features.Mediator.Results.CarDescriptionResult;

namespace RentCar.Application.Features.Mediator.Queries.CarDescriptionQueries
{
    public class GetCarDescriptionByCarIdQuery : IRequest<List<GetCarDescriptionQueryResult>>
    {
        public int Id { get; set; }

        public GetCarDescriptionByCarIdQuery(int id)
        {
            Id = id;
        }
    }
}
