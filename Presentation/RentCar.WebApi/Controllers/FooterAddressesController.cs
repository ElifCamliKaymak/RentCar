using MediatR;
using Microsoft.AspNetCore.Mvc;
using RentCar.Application.Features.Mediator.Commands.FooterAddressCommands;
using RentCar.Application.Features.Mediator.Queries.FooterAddressQueries;

namespace RentCar.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FooterAddressesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public FooterAddressesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> FooterAdressList()
        {
            var values = await _mediator.Send(new GetFooterAddressQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFooterAdress(int id)
        {
            var value = await _mediator.Send(new GetFooterAddressByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFooterAdress(CreateFooterAddressCommand command)
        {
            await _mediator.Send(command);
            return Ok("Footer Address başarıyla eklendi.");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveFooterAdress(int id)
        {
            await _mediator.Send(new RemoveFooterAddressCommand(id));
            return Ok("Footer Address bilgisi silindi.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateRemove(UpdateFooterAddressCommand command)
        {
            await _mediator.Send(command);
            return Ok("Footer Address bilgisi güncellendi.");
        }
    }
}
