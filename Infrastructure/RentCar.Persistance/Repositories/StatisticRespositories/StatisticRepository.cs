using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using RentCar.Application.Interfaces.StatisticInterfaces;
using RentCar.Persistance.Context;
using System.Net.Http.Json;
using System.Text.Json.Serialization;

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

        public async Task<(string,int)> GetBlogTitleByMaximumBlogComment()
        {
            var result = await _context.Blogs
                .Join(_context.Comments,
                    b => b.BlogId,
                    c => c.BlogId, (b, c)
                    => new { b, c })
                .GroupBy(x => x.b.Title)
                .OrderByDescending(x => x.Count())
                .Select(x => new { BlogTitle = x.Key, Count = x.Count() })
                .FirstOrDefaultAsync();

            return (result.BlogTitle,result.Count);
        }

        public async Task<int> GetBrandCount()
        {
            return await _context.Brands.CountAsync();
        }

        public async Task<(string,int)> GetBrandNameByMaximumCar()
        {
            var result = await _context.Brands
                .Join(_context.Cars,
                    b => b.BrandId,
                    c => c.BrandId, (b, c)
                    => new { b, c })
                .GroupBy(x => x.c.Brand.Name)
                .OrderByDescending(x => x.Count())
                .Select(x => new { BrandName = x.Key, Count = x.Count() })
            .FirstOrDefaultAsync();
                       
            return (result.BrandName, result.Count);
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
