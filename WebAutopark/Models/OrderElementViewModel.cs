    using System.ComponentModel.DataAnnotations;

namespace WebAutopark.Models
{
    public class OrderElementViewModel
    {
        [Required]
        public int OrderElementId { get; set; }

        [Required]
        public int OrderId { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Count can't be < 1.")]
        public int Quantity { get; set; }

        [Required]
        public int DetailId { get; set; }

        public DetailViewModel Detail { get; set; }
    }
}
