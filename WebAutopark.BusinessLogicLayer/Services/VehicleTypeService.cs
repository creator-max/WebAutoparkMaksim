using WebAutopark.BusinessLogicLayer.Services.Base;
using WebAutopark.BusinessLogicLayer.DataTransferObjects;
using WebAutopark.DataAccesLayer.Entities;
using WebAutopark.DataAccesLayer.Interfaces;
using AutoMapper;

namespace WebAutopark.BusinessLogicLayer.Services
{
    public class VehicleTypeService : BaseService<VehicleTypeDTO, VehicleType>
    {
        public VehicleTypeService(IRepository<VehicleType> repository, IMapper mapper)
            : base(repository, mapper)
        { }
    }
}
