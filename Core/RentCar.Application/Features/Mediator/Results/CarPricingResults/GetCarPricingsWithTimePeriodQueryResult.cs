namespace RentCar.Application.Features.Mediator.Results.CarPricingResults
{
	public class GetCarPricingsWithTimePeriodQueryResult
	{
        public string BrandAndModelName { get; set; }
        public decimal DailyAmount { get; set; }
        public decimal WeeklyAmount { get; set; }
        public decimal MonthlyAmount { get; set; }
    }
}
