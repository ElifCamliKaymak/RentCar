namespace RentCar.ViewModels.CarRentalProcessVms
{
    public class CreateCarRentalProcessVM
    {
        public string? PickUpDescription { get; set; }
        public string? DropOffDescription { get; set; }
        public DateTime PickUpDate { get; set; }
        public DateTime DropOffDate { get; set; }
        public decimal? TotalPrice { get; set; }
        public bool IsAvailable { get; set; } = true;

        public int PickUpLocationId { get; set; }
        public int DropOffLocationId { get; set; }
        public int? CarId { get; set; }
        public int? CustomerId { get; set; }
    }
}
