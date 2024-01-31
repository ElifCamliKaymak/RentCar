using RentCar.Domain.Entities;

namespace RentCar.Application.Interfaces.CarDescriptionInterfaces
{
    public interface ICarDescriptionRepository
    {
        Task<List<CarDescription>> GetCarDescriptionAsync(int carId);
    }
}
