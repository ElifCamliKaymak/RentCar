using Microsoft.EntityFrameworkCore;
using RentCar.Application.Features.Mediator.Queries.StatisticQueries;
using RentCar.Application.Features.Mediator.Results.CarPricingResults;
using RentCar.Application.Interfaces.CarPricingInterfaces;
using RentCar.Domain.Dtos.CarPricingDtos;
using RentCar.Domain.Entities;
using RentCar.Persistance.Context;

namespace RentCar.Persistance.Repositories.CarPricingRepositories
{
    public class CarPricingRepository : ICarPricingRepository
    {
        private readonly RentCarContext _context;

        public CarPricingRepository(RentCarContext context)
        {
            _context = context;
        }

        public async Task<List<CarPricingsWithPricingTimePeriodDto>> GetCarPricingsWithTimePeriodAsync()
        {
            var pivotTable = await _context.CarPricings
                .Join(_context.Cars,
                    cp => cp.CarId,
                    c => c.CarId,
                    (cp, c) => new
                    {
                        BrandName = c.Brand.Name,
                        Model = c.Model,
                        PricingId = cp.PricingId,
                        Amount = cp.Amount,
                        CoverImageUrl = cp.Car.CoverImagerUrl
                    })
                .GroupBy(x => new { x.BrandName, x.Model, x.CoverImageUrl })
                .Select(g => new CarPricingsWithPricingTimePeriodDto
                {
                    ModelBrandName = g.Key.BrandName + " " + g.Key.Model,
                    CoverImageUrl = g.Key.CoverImageUrl,
                    DailyAmount = g.Where(x => x.PricingId == 3).Sum(x => x.Amount),
                    WeeklyAmount = g.Where(x => x.PricingId == 4).Sum(x => x.Amount),
                    MonthlyAmount = g.Where(x => x.PricingId == 5).Sum(x => x.Amount)
                }).ToListAsync();    

            return pivotTable;
        }

        public async Task<List<CarPricing>> GetCarPricingWithCars()
        {

            var values = await _context.CarPricings
                .Include(cp => cp.Car)
                .ThenInclude(c => c.Brand)
                .Include(cp => cp.Pricing)
                .Where(x => x.Pricing.Name == "Günlük")
                .ToListAsync();
            return values;

        }
    }
}
