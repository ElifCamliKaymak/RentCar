﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentCar.Application.Features.CQRS.Commands.BrandCommands;
using RentCar.Application.Features.CQRS.Handlers.BrandHandlers;
using RentCar.Application.Features.CQRS.Queries.BrandQueries;
using RentCar.Application.Validators.BrandValidators;

namespace RentCar.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly GetBrandQueryHandler _getBrandQueryHandler;
        private readonly GetBrandByIdQueryHandler _getBrandByIdQueryHandler;
        private readonly CreateBrandCommandHandler _createBrandCommandHandler;
        private readonly UpdateBrandCommandHandler _updateBrandCommandHandler;
        private readonly RemoveBrandCommandHandler _removeBrandCommandHandler;
        private readonly CreateBrandValidator _createBrandValidator;
        private readonly UpdateBrandValidator _updateBrandValidator;

        public BrandsController(GetBrandQueryHandler getBrandQueryHandler, GetBrandByIdQueryHandler getBrandByIdQueryHandler, CreateBrandCommandHandler createBrandCommandHandler, UpdateBrandCommandHandler updateBrandCommandHandler, RemoveBrandCommandHandler removeBrandCommandHandler, CreateBrandValidator createBrandValidator, UpdateBrandValidator updateBrandValidator)
        {
            _getBrandQueryHandler = getBrandQueryHandler;
            _getBrandByIdQueryHandler = getBrandByIdQueryHandler;
            _createBrandCommandHandler = createBrandCommandHandler;
            _updateBrandCommandHandler = updateBrandCommandHandler;
            _removeBrandCommandHandler = removeBrandCommandHandler;
            _createBrandValidator = createBrandValidator;
            _updateBrandValidator = updateBrandValidator;
        }

        [HttpGet]
        public async Task<IActionResult> BrandList()
        {
            var values = await _getBrandQueryHandler.Handle();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBrand(int id)
        {
            var value=await _getBrandByIdQueryHandler.Handle(new GetBrandByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBrand(CreateBrandCommand command)
        {
            var validationResult = _createBrandValidator.Validate(command);
            if (validationResult.IsValid)
            {
                await _createBrandCommandHandler.Handle(command);
                return Ok("Brand bilgisi eklendi.");
            }
            return BadRequest("Hay aksi! Bir şeyler ters gitti...");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveBrand(int id)
        {
            await _removeBrandCommandHandler.Handle(new RemoveBrandCommand(id));
            return Ok("Brand bilgisi silindi.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBrand(UpdateBrandCommand command)
        {
            var validationResult=_updateBrandValidator.Validate(command);
            if (validationResult.IsValid)
            {
                await _updateBrandCommandHandler.Handle(command);
                return Ok("Brand bilgisi güncellendi.");
            }
            return BadRequest("Hay aksi! Bir şeyler ters gitti...");
        }
    }
}
