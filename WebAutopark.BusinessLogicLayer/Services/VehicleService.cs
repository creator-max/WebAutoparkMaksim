using WebAutopark.BusinessLogicLayer.Services.Base;
using WebAutopark.BusinessLogicLayer.DataTransferObjects;
using WebAutopark.DataAccesLayer.Entities;
using WebAutopark.DataAccesLayer.Interfaces;
using AutoMapper;
using System.Threading.Tasks;

namespace WebAutopark.BusinessLogicLayer.Services
{
    public class VehicleService : BaseService<VehicleDto, Vehicle>
    {
        public VehicleService(IRepository<Vehicle> vehicleRepository, IMapper mapper)
            : base(vehicleRepository, mapper)
        { }
    }
}
