using Microsoft.EntityFrameworkCore;
using RentCar.Application.Interfaces.StatisticInterfaces;
using RentCar.Persistance.Context;

namespace RentCar.Persistance.Repositories.StatisticRespositories
{
    public class StatisticRepository : IStatisticRepository
    {
        private readonly RentCarContext _context;

        public StatisticRepository(RentCarContext context)
        {
            _context = context;
        }

        public async Task<int> GetAuthorCountAsync()
        {
            return await _context.Authors.CountAsync();
        }

        public async Task<double> GetAverageRentPriceForDaily()
        {
            return Convert.ToDouble(
                await _context.CarPricings
                .Join(_context.Pricings,
                    cp => cp.PricingId,
                    p => p.PricingId, (cp, p)
                    => new { cp, p })
                .Where(x => x.p.Name == "Günlük")
                .AverageAsync(x => x.cp.Amount));
        }

        public async Task<double> GetAverageRentPriceForMonthly()
        {
            return Convert.ToDouble(
                await _context.CarPricings
                .Join(_context.Pricings,
                    cp => cp.PricingId,
                    p => p.PricingId, (cp, p)
                    => new { cp, p })
                .Where(x => x.p.Name == "Aylık")
                .AverageAsync(x => x.cp.Amount));
        }

        public async Task<double> GetAverageRentPriceForWeekly()
        {
            return Convert.ToDouble(
                await _context.CarPricings
                .Join(_context.Pricings,
                    cp => cp.PricingId,
                    p => p.PricingId, (cp, p)
                    => new { cp, p })
                .Where(x => x.p.Name == "Haftalık")
                .AverageAsync(x => x.cp.Amount));
        }

        public async Task<int> GetBlogCount()
        {
            return await _context.Blogs.CountAsync();
        }

        public async Task<string> GetBlogTitleByMaximumBlogComment()
        {

            return "ok";
        }

        public async Task<int> GetBrandCount()
        {
            return await _context.Brands.CountAsync();
        }

        public async Task<string> GetBrandNameByMaximumCar()
        {
            //return await _context.Cars.Include(x=>x.Brand).GroupBy(x=>x.BrandId).OrderByDescending(x=>x.Key).Select(x=>x.;
            return "";
        }

        public async Task<string> GetCarBrandAndModelByRentPriceDailyMax()
        {
            throw new NotImplementedException();
        }

        public Task<string> GetCarBrandAndModelByRentPriceDailyMin()
        {
            throw new NotImplementedException();
        }

        public async Task<int> GetCarCountAsync()
        {
            return await _context.Cars.CountAsync();
        }

        public async Task<int> GetCarCountByFuelElectric()
        {
            return await _context.Cars.Where(x => x.Fuel == "Elektrik").CountAsync();
        }

        public async Task<int> GetCarCountByFuelGasolineOrDiesel()
        {
            return await _context.Cars.Where(x => x.Fuel == "Benzin" || x.Fuel == "Dizel").CountAsync();
        }

        public async Task<int> GetCarCountByKmSmallerThen1000()
        {
            return await _context.Cars.Where(x => x.Km < 1000).CountAsync();
        }

        public async Task<int> GetCarCountByTransmissionIsAuto()
        {
            return await _context.Cars.Where(x => x.Transmission == "Otomatik").CountAsync();
        }

        public async Task<int> GetLocationCountAsync()
        {
            return await _context.Locations.CountAsync();
        }
    }
}
