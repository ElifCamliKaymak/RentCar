namespace RentCar.Domain.Entities
{
    public class CarRentalProcess
    {
        public int CarRentalProcessId { get; set; }
        public string PickUpDescription { get; set; }
        public string DropOffDescription { get; set; }
        public DateTime PickUpDate { get; set; }
        public DateTime DropOffDate { get; set; }
        public decimal TotalPrice { get; set; }

        public int PickUpLocationId { get; set; }
        public Location PickUpLocation { get; set; }
        public int DropOffLocationId { get; set; }
        public Location DropOffLocation { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
