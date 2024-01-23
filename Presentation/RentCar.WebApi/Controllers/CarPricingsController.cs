using MediatR;
using Microsoft.AspNetCore.Mvc;
using RentCar.Application.Features.Mediator.Queries.CarPricingQueries;

namespace RentCar.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarPricingsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarPricingsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetCarPricingWithCarList()
        {
            var values = await _mediator.Send(new GetCarPricingWithCarQuery());
            return Ok(values);
        }

        [HttpGet("GetCarPricingsWithTimePeriodList")]
        public async Task<IActionResult> GetCarPricingsWithTimePeriodList()
        {
            var values = await _mediator.Send(new GetCarPricingsWithTimePeriodQuery());
            return Ok(values);
        }
    }
}
