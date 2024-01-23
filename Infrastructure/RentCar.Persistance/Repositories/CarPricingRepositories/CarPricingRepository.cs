using Microsoft.EntityFrameworkCore;
using RentCar.Application.Features.Mediator.Results.CarPricingResults;
using RentCar.Application.Interfaces.CarPricingInterfaces;
using RentCar.Domain.Dtos.CarPricingDtos;
using RentCar.Domain.Entities;
using RentCar.Persistance.Context;

namespace RentCar.Persistance.Repositories.CarPricingRepositories
{
	public class CarPricingRepository : ICarPricingRepository
	{
		private readonly RentCarContext _context;

		public CarPricingRepository(RentCarContext context)
		{
			_context = context;
		}

		public async Task<List<CarPricingsWithPricingTimePeriodDto>> GetCarPricingsWithTimePeriodAsync()
		{
			var values = await _context.CarPricings
				.Join(_context.Cars,
					cp => cp.CarId,
					c => c.CarId, (cp, c)
					=> new { cp, c })
				.Join(_context.Pricings,
					x => x.cp.PricingId,
					p => p.PricingId, (x, c)
					=> new { x, c })
				.GroupBy(a => a.x.c.Model)
				.Select(b => new CarPricingsWithPricingTimePeriodDto
				{
					BrandAndModelName = b.Key,
					Amounts = b.SelectMany(item => item.c.CarPricings.Where(x => x.Car.Model == b.Key).Select(h => h.Amount)).ToList()
				}).ToListAsync();

			return values;
		}

		public async Task<List<CarPricing>> GetCarPricingWithCars()
		{

			var values = await _context.CarPricings
				.Include(cp => cp.Car)
				.ThenInclude(c => c.Brand)
				.Include(cp => cp.Pricing)
				.Where(x => x.Pricing.Name == "Günlük")
				.ToListAsync();
			return values;

		}
	}
}
