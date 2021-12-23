using System.ComponentModel.DataAnnotations;

namespace WebAutopark.Models
{
    public class DetailViewModel
    {
        [Required]
        public int DetailId { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "DetailName length must be 3-50 characters")]
        public string DetailName { get; set; }
    }
}
