using Microsoft.EntityFrameworkCore;
using RentCar.Application.Interfaces.CarDescriptionInterfaces;
using RentCar.Domain.Entities;
using RentCar.Persistance.Context;

namespace RentCar.Persistance.Repositories.CarDescriptionRepositories
{
    public class CarDescriptionRepository : ICarDescriptionRepository
    {
        private readonly RentCarContext _context;

        public CarDescriptionRepository(RentCarContext context)
        {
            _context = context;
        }

        public async Task<List<CarDescription>> GetCarDescriptionAsync(int carId)
        {
            return await _context.CarDescriptions.Where(x=>x.CarId == carId).ToListAsync();
        }
    }
}

