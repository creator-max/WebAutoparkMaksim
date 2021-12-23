using WebAutopark.BusinessLogicLayer.Interfaces;

namespace WebAutopark.BusinessLogicLayer.DataTransferObjects
{
    public class DetailDto : IBusinessDto
    {
        public int DetailId { get; set; }
        public string DetailName { get; set; }
    }
}
