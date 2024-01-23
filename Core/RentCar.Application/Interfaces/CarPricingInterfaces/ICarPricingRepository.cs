using RentCar.Domain.Dtos.CarPricingDtos;
using RentCar.Domain.Entities;

namespace RentCar.Application.Interfaces.CarPricingInterfaces
{
	public interface ICarPricingRepository
    {
        Task<List<CarPricing>> GetCarPricingWithCars();
        Task<List<CarPricingsWithPricingTimePeriodDto>> GetCarPricingsWithTimePeriodAsync();

	}
}