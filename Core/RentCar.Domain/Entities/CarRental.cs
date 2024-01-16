namespace RentCar.Domain.Entities
{
    public class CarRental
    {
        public int CarRentalId { get; set; }
        public bool IsAvailable { get; set; }

        public int LocationId { get; set; }
        public Location Location { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; }
        

    }
}
