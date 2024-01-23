namespace RentCar.Domain.Entities
{
    public class Location
    {
        public int LocationId { get; set; }
        public string Name { get; set; }

        public List<CarRental> CarRentals { get; set; }
        public List<CarRentalProcess> CarRentalProcessesForPickUp { get; set; }      
        public List<CarRentalProcess> CarRentalProcessesForDropOff { get; set; }        
        public List<Reservation> PickUpReservations { get; set; }      
        public List<Reservation> DropOffReservations { get; set; }

    }
}
