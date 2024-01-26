using Microsoft.AspNetCore.Mvc;
using RentCar.ViewModels.CarFeatureVms;

namespace RentCar.ViewModels.CarVms
{
    public class CreateCarVM
    {

        public int BrandId { get; set; }
        public string Model { get; set; }
        public string CoverImagerUrl { get; set; }
        public int Km { get; set; }
        public string Transmission { get; set; }
        public byte Seat { get; set; }
        public byte Luggage { get; set; }
        public string Fuel { get; set; }
        public string BigImageUrl { get; set; }
        public List<int> CarFeatures { get; set; } = new List<int>();
    }
}
