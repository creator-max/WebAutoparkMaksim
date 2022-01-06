using System;

namespace WebAutopark.BusinessLogicLayer.DataTransferObjects
{
    public class OrderDTO
    {
        public int OrderId { get; set; }
        public int VehicleId { get; set; }
        public DateTime Date { get; set; }
    }
}
