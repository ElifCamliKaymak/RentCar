using MediatR;
using Microsoft.AspNetCore.Mvc;
using RentCar.Application.Features.Mediator.Queries.CarRentalQueries;

namespace RentCar.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarRentalsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarRentalsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{locationId}/{isAvailable}")]
        public async Task<IActionResult> GetCarRentalListByLocation(int locationId, bool isAvailable)
        {
            GetCarRentalQuery query = new GetCarRentalQuery()
            {
                LocationId = locationId,
                IsAvailable = isAvailable
            };
            
            var values = await _mediator.Send(query);
            return Ok(values);
        }
    }
}
