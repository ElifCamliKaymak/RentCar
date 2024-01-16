using Microsoft.EntityFrameworkCore;
using RentCar.Application.Interfaces.CarRentalInterfaces;
using RentCar.Domain.Entities;
using RentCar.Persistance.Context;
using System.Linq.Expressions;

namespace RentCar.Persistance.Repositories.CarRentalRepositories
{
    public class CarRentalRepository : ICarRentalRepository
    {
        private readonly RentCarContext _context;

        public CarRentalRepository(RentCarContext context)
        {
            _context = context;
        }

        public async Task<List<CarRental>> GetByFilterAsync(Expression<Func<CarRental, bool>> filter)
        {
            return await _context.CarRentals.Where(filter).ToListAsync();
        }
    }
}
