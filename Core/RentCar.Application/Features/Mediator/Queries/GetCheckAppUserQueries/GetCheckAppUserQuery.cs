using MediatR;
using RentCar.Application.Features.Mediator.Results.AppUserResults;

namespace RentCar.Application.Features.Mediator.Queries.GetCheckAppUserQueries
{
    public class GetCheckAppUserQuery : IRequest<GetCheckAppUserQueryResult>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
