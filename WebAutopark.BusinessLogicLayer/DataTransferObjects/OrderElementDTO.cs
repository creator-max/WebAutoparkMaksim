namespace WebAutopark.BusinessLogicLayer.DataTransferObjects
{
    public class OrderElementDTO
    {
        public int OrderElementId { get; set; }
        public int OrderId { get; set; }
        public int DetailId { get; set; }
        public int Quantity { get; set; }
        public DetailDTO Detail { get; set; }
    }
}