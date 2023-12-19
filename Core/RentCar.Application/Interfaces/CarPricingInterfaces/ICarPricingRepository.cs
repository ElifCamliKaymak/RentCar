using RentCar.Domain.Entities;

namespace RentCar.Application.Interfaces.CarPricingInterfaces
{
    public interface ICarPricingRepository
    {
        Task<List<CarPricing>> GetCarPricingWithCars();
    }
}
