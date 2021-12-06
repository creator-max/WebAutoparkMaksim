namespace WebAutopark.DataAccesLayer.Entities
{
    public class OrderElement
    {
        public int OrderElementId { get; set; }
        public int OrderId { get; set; }
        public int DetailId { get; set; }
        public int Quantity { get; set; }
    }
}
