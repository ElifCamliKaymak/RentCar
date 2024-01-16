namespace RentCar.Domain.Entities
{
    public class Location
    {
        public int LocationId { get; set; }
        public string Name { get; set; }

        public List<CarRental> CarRentals { get; set; }
    }
}
