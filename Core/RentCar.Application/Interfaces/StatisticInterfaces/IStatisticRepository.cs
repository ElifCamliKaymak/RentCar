namespace RentCar.Application.Interfaces.StatisticInterfaces
{
    public interface IStatisticRepository
    {
        Task<int> GetCarCountAsync();
        Task<int> GetLocationCountAsync();
        Task<int> GetAuthorCountAsync();
        Task<int> GetBlogCount();
        Task<int> GetBrandCount();
        Task<double> GetAverageRentPriceForDaily();
        Task<double> GetAverageRentPriceForWeekly();
        Task<double> GetAverageRentPriceForMonthly();
        Task<int> GetCarCountByTransmissionIsAuto();
        Task<(string,int)> GetBrandNameByMaximumCar();
        Task<(string,int)> GetBlogTitleByMaximumBlogComment();
        Task<int> GetCarCountByKmSmallerThen1000();
        Task<int> GetCarCountByFuelGasolineOrDiesel();
        Task<int> GetCarCountByFuelElectric();
        Task<string> GetCarBrandAndModelByRentPriceDailyMax();
        Task<string> GetCarBrandAndModelByRentPriceDailyMin();
    }
}
