namespace WebAutopark.DataAccesLayer.Entities
{
    public class Vehicle
    {
        private const double WeightCoefficient = 0.0013d;
        private const double TaxCoefficient = 30d;
        private const double TaxPerMonthAddition = 5d;

        public int VehicleId { get; set; }
        public int VehicleTypeId { get; set; }
        public VehicleType VehicleType { get; set; }
        public string Model { get; set; }
        public ushort YearOfIssue { get; set; }
        public double Weight { get; set; }
        public double TankCapacity { get; set; }
        public string LicensePlat { get; set; }
        public double MileageKm { get; set; }
        public Color Color { get; set; }
        public double TaxPerMonth => VehicleType is not null 
            ? Weight * WeightCoefficient + VehicleType.TaxCoefficient * 
            TaxCoefficient + TaxPerMonthAddition 
            : 0;
    }
}