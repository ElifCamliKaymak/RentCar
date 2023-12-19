using Microsoft.EntityFrameworkCore;
using RentCar.Application.Interfaces.CarPricingInterfaces;
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

        public async Task<List<CarPricing>> GetCarPricingWithCars()
        {

            var values = await _context.CarPricings
                .Include(cp => cp.Car)
                .ThenInclude(c => c.Brand)
                .Include(cp => cp.Pricing)
                .Where(x => x.PricingId == 2)
                .ToListAsync();
            return values;

        }
    }
}
