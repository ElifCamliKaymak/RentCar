using RentCar.Domain.Entities;

namespace RentCar.Application.Interfaces.CarFeatureInterfaces
{
    public interface ICarFeatureRepository
    {
        Task<List<CarFeature>> GetCarFeaturesByCarId(int carId); 
    }
}
