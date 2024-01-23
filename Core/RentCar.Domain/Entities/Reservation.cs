using RentCar.Domain.Enums;

namespace RentCar.Domain.Entities
{
    public class Reservation
    {
        public int ReservationId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public byte Age { get; set; }
        public int DriverLicenceYear { get; set; }
        public string? Description { get; set; }

        public int CarId { get; set; }
        public Car Car { get; set; }
        public int? PickUpLocationId { get; set; }
        public Location PickUpLocation { get; set; }
        public int? DropOffLocationId { get; set; }
        public Location DropOffLocation { get; set; }
        public Status Status { get; set; }
    }
}
