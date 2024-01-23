namespace RentCar.Domain.Dtos.CarPricingDtos
{
	public class CarPricingsWithPricingTimePeriodDto
	{
        public string ModelBrandName { get; set; }
        public string CoverImageUrl { get; set; }
        public decimal DailyAmount { get; set; }
        public decimal WeeklyAmount { get; set; }
        public decimal MonthlyAmount { get; set; }
    }
}
