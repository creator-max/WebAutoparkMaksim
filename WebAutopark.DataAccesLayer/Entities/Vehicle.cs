namespace WebAutopark.DataAccesLayer.Entities
{
    public class Vehicle
    {
        public int VehicleId { get; set; }
        public string Model { get; set; }
        public string ImageLink { get; set; }
        public double Price { get; set; }
        public int YearOfIssue { get; set; }
        public double Weight { get; set; }
        public double TankCapacity { get; set; }
        public string LicensePlate { get; set; }
        public double Mileage { get; set; }
        public Color Color { get; set; }
        public double FuelConsumption { get; set; }
        public int VehicleTypeId { get; set; }
        public VehicleType VehicleType { get; set; }
    }
}