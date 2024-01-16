namespace RentCar.ViewModels.StatisticsVms
{
    public class ResultStatisticVM
    {
        public int CarCount { get; set; }
        public int LocationCount { get; set; }
        public int AuthorCount { get; set; }
        public int BlogCount { get; set; }
        public int BrandCount { get; set; }
        public double AveragePriceForDaily { get; set; }
        public double AveragePriceForWeekly { get; set; }
        public double AveragePriceForMonthly { get; set; }
        public int CarCountByTransmissionIsAuto { get; set; }
        public string BrandNameByMaximumCar { get; set; }
        public int BrandCountByMaximumCar { get; set; }
        public string BlogTitleByMaximumBlogComment { get; set; }
        public int BlogCountByMaximumBlogComment { get; set; }
        public int CarCountByKmSmallerThen1000 { get; set; }
        public int CarCountByFuelGasolineOrDiesel { get; set; }
        public int CarCountByFuelElectricectric { get; set; }
        public int CarCountByFuelElectric { get; set; }
        public string CarBrandAndModelByRentPriceDailyMax { get; set; }
        public string CarBrandAndModelByRentPriceDailyMin { get; set; }
    }
}
