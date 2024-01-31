using MediatR;
using Microsoft.AspNetCore.Mvc;
using RentCar.Application.Features.Mediator.Queries.CarDescriptionQueries;

namespace RentCar.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarDescriptionsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarDescriptionsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("CarDescriptionByCar/{id}")]
        public async Task<IActionResult> CarDescriptionByCar(int id)
        {
            var values = await _mediator.Send(new GetCarDescriptionByCarIdQuery(id));
            return Ok(values);
        }
    }
}
