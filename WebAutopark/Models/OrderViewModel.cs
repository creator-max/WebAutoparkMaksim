using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebAutopark.Models
{
    public class OrderViewModel
    {
        [Required]
        public int OrderId { get; set; }

        [Required]
        public int VehicleId { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public List<OrderElementViewModel> OrderElements { get; set; }
    }
}
