using RentCar.Domain.Entities;
using System.Linq.Expressions;

namespace RentCar.Application.Interfaces.CarRentalInterfaces
{
    public interface ICarRentalRepository
    {
        Task<List<CarRental>> GetByFilterAsync(Expression<Func<CarRental,bool>> filter);
    }
}
