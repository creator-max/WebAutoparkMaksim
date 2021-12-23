using WebAutopark.BusinessLogicLayer.Interfaces;

namespace WebAutopark.BusinessLogicLayer.DataTransferObjects
{
    public class VehicleTypeDto : IBusinessDto
    {
        public int TypeId { get; set; }
        public string TypeName { get; set; }
        public double TaxCoefficient { get; set; }
    }
}
