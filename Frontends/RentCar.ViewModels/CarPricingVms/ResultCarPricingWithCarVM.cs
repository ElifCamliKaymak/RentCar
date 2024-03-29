﻿namespace RentCar.ViewModels.CarPricingVms
{
    public class ResultCarPricingWithCarVM
    {
        public int CarId { get; set; }
        public int CarPricingId { get; set; }
        public string BrandName { get; set; }
        public string Model { get; set; }
        public decimal Amount { get; set; }
        public string CoverImageUrl { get; set; }
    }
}
