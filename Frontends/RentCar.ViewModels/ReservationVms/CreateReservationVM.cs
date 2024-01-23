namespace RentCar.ViewModels.ReservationVms
{
    public class CreateReservationVM
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public byte Age { get; set; }
        public int DriverLicenceYear { get; set; }
        public string Description { get; set; }

        public int CarId { get; set; }
        public int PickUpLocationId { get; set; }
        public int DropOffLocationId { get; set; }
    }
}
