using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentCar.Application.Features.Mediator.Commands.LocationCommands;
using RentCar.Application.Features.Mediator.Queries.LocationQueries;

namespace RentCar.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly IMediator _mediator;
        public LocationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> FooterAdressList()
        {
            var values = await _mediator.Send(new GetLocationQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFooterAdress(int id)
        {
            var value = await _mediator.Send(new GetLocationByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFooterAdress(CreateLocationCommand command)
        {
            await _mediator.Send(command);
            return Ok("Konum başarıyla eklendi.");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveFooterAdress(int id)
        {
            await _mediator.Send(new RemoveLocationCommand(id));
            return Ok("Konum bilgisi silindi.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateRemove(UpdateLocationCommand command)
        {
            await _mediator.Send(command);
            return Ok("Konum bilgisi güncellendi.");
        }
    }
}
