using Microsoft.EntityFrameworkCore;
using RentCar.Application.Interfaces.CarFeatureInterfaces;
using RentCar.Domain.Entities;
using RentCar.Persistance.Context;

namespace RentCar.Persistance.Repositories.CarFeatureRepositories
{
    public class CarFeatureRepository : ICarFeatureRepository
    {
        private readonly RentCarContext _context;

        public CarFeatureRepository(RentCarContext context)
        {
            _context = context;
        }

        public async Task<List<CarFeature>> GetCarFeaturesByCarId(int carId)
        {
            var values = await _context
                .CarFeatures
                .Include(x=>x.Feature)
                .Where(x=>x.CarId==carId)
                .ToListAsync();
            return values;
        }
    }
}
