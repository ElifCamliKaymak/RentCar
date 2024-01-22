namespace RentCar.Application.Features.Mediator.Results.CarRentalResults
{
    public class GetCarRentalQueryResult
    {
        public int CarId { get; set; }
        public string BrandName { get; set; }
        public string Model { get; set; }
        public decimal Amount { get; set; }
        public string CoverImageUrl { get; set; }
    }
}
