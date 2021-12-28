using System;
using System.ComponentModel.DataAnnotations;
using WebAutopark.BusinessLogicLayer.DataTransferObjects;

namespace WebAutopark.Models
{
    public class VehicleViewModel
    {
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
        [Range(1, int.MaxValue)]
        public int YearOfIssue { get; set; }

        public double Weight { get; set; }

        [Required]
        [Range(20, 100, ErrorMessage = "Tank Capacity must be between 20 and 100")]
        public double TankCapacity { get; set; }

        public string LicensePlate { get; set; }

        [Required]
        [Range(0, 1000000, ErrorMessage = "Mileage must be between 0 and 100000")]
        public double Mileage { get; set; }

        [Required]
        public Color Color { get; set; }

        public int VehicleTypeId { get; set; }
    }
}
