using RentCar.Domain.Entities;

namespace RentCar.Application.Interfaces.CarInterfaces
{
    public interface ICarRepository
    {
        Task<List<Car>> GetCarsListWithBrand();
        Task<List<Car>> GetLastFiveCarsWithBrandsAsync();
    }
}
