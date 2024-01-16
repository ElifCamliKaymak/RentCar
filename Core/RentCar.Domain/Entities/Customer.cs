using System.ComponentModel.DataAnnotations.Schema;

namespace RentCar.Domain.Entities
{
    public class Customer
    {
        public int CustomerId { get; set; }

        [NotMapped]
        public string CustomerName { get; set; }

        [NotMapped]
        public string CustomerSurname { get; set; }
        public string CustomerFullName => $"{CustomerName} {CustomerSurname}";
        public string CustomerMail { get; set; }
        public List<CarRentalProcess> CarRentalProcesses { get; set; }
    }
}
