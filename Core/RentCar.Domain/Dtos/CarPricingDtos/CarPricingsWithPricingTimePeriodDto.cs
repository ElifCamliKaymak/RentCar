namespace RentCar.Domain.Dtos.CarPricingDtos
{
	public class CarPricingsWithPricingTimePeriodDto
	{
        public string BrandAndModelName { get; set; }
		public List<decimal> Amounts { get; set; }
	}
}
