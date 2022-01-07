namespace WebAutopark.BusinessLogicLayer.DataTransferObjects
{
    public class OrderElementDto
    {
        public int OrderElementId { get; set; }
        public int OrderId { get; set; }
        public int DetailId { get; set; }
        public int Quantity { get; set; }
        public DetailDto Detail { get; set; }
    }
}