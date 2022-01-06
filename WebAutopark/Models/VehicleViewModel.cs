using System;
using System.ComponentModel.DataAnnotations;
using WebAutopark.BusinessLogicLayer.DataTransferObjects;

namespace WebAutopark.Models
{
    public class VehicleViewModel
    {
        private const double WeightCoefficient = 0.0013d;
        private const double TaxCoefficient = 30d;
        private const double TaxPerMonthAddition = 5d;

        [Required]
        public int VehicleId { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Model name length must be from 3 to 50 chars.")]
        public string Model { get; set; }

        public string ImageLink { get; set; }

        [Required]
        [Range(1000, 1000000, ErrorMessage = "Price must be between $1000 and $1000000")]
        public double Price { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Invalid value for Year.")]
        public int YearOfIssue { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Invalid value for Weight.")]
        public double Weight { get; set; }

        [Required]
        [Range(1, 100000, ErrorMessage = "Tank Capacity must be between 1 and 100000")]
        public double TankCapacity { get; set; }

        public string LicensePlate { get; set; }

        [Required]
        [Range(0, 1000000, ErrorMessage = "Mileage must be between 0 and 100000")]
        public double Mileage { get; set; }

        [Required]
        public Color Color { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Invalid value for FuelConsumption.")]
        public double FuelConsumption { get; set; }

        public int VehicleTypeId { get; set; }
        public VehicleTypeViewModel VehicleType { get; set; }

        public double GetCalcTaxPerMonth => Weight * WeightCoefficient +
            VehicleType.TaxCoefficient * TaxCoefficient + TaxPerMonthAddition;

        public double GetCalcMaxKm => FuelConsumption != 0 
            ? TankCapacity / FuelConsumption 
            : TankCapacity;

    }
}
