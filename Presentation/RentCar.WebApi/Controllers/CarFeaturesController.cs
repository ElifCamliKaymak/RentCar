using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentCar.Application.Features.Mediator.Commands.CarFeatureCommands;
using RentCar.Application.Features.Mediator.Queries.CarFeatureQueries;

namespace RentCar.WebApi.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class CarFeaturesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarFeaturesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("CarFeaturesListByCar/{id}")]
        public async Task<IActionResult> CarFeaturesListByCar (int id)
        {
            var values = await _mediator.Send(new GetCarFeatureByCarIdQuery(id));
            return Ok(values);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBrand(UpdateCarFeatureCommand command)
        {
            await _mediator.Send(command);
            return Ok("Araç özellik bilgisi güncellendi.");
        }
    }
}
