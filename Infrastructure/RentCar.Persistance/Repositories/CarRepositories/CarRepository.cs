using Microsoft.EntityFrameworkCore;
using RentCar.Application.Interfaces.CarInterfaces;
using RentCar.Domain.Entities;
using RentCar.Persistance.Context;

namespace RentCar.Persistance.Repositories.CarRepositories
{
    public class CarRepository : ICarRepository
    {
        private readonly RentCarContext _context;

        public CarRepository(RentCarContext context)
        {
            _context = context;
        }

        public async Task<List<Car>> GetCarsListWithBrand()
        {
            return await _context.Cars
                .Include(x => x.Brand)
                .ToListAsync();
        }

        public async Task<List<Car>> GetCarListByBrandId(int id)
        {
            return await _context.Cars
                .Include(x => x.Brand)
                .Where(x=>x.BrandId == id)
                .ToListAsync();
        }

        public async Task<List<Car>> GetLastFiveCarsWithBrandsAsync()
        {
            var values = await _context.Cars
                .Include(x => x.Brand)
                .OrderByDescending(x => x.CarId)
                .Take(5)
                .ToListAsync();
            return values;
        }
    }
}
