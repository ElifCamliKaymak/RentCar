namespace RentCar.ViewModels.CarFeatureVms
{
    public class UpdateCarFeatureVM
    {
        public int CarFeatureId { get; set; }
        public int CarId { get; set; }
        public int FeatureId { get; set; }
        public bool Available { get; set; }
    }
}
