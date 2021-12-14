namespace WebAutopark.DataAccesLayer.Entities
{
    public class Vehicle
    {
        public int VehicleId { get; set; }
        public string Model { get; set; }
        public int YearOfIssue { get; set; }
        public double Weight { get; set; }
        public double TankCapacity { get; set; }
        public string LicensePlat { get; set; }
        public double Mileage { get; set; }
        public Color Color { get; set; }
        public int VehicleTypeId { get; set; }
        public VehicleType VehicleType { get; set; }
    }
}