using MediatR;
using RentCar.Application.Features.Mediator.Results.FooterAddressResults;

namespace RentCar.Application.Features.Mediator.Queries.FooterAddressQueries
{
    public class GetFooterAddressQuery : IRequest<List<GetFooterAddressQueryResult>>
    {

    }
}
