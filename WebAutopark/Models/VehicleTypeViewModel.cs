using System.ComponentModel.DataAnnotations;

namespace WebAutopark.Models
{
    public class VehicleTypeViewModel
    {
        [Required]
        public int TypeId { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Max length: 50.")]
        public string TypeName { get; set; }

        [Required]
        [Range(0.5, 3, ErrorMessage = "Tax Coefficient must be from 0.5 to 3.0")]
        public double TaxCoefficient { get; set; }
    }
}
