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
        IRepository<VehicleType> _vehicleTypeRepository;
        public VehicleService(IRepository<Vehicle> vehicleRepository,
                              IRepository<VehicleType> vehicleTypeRepository,
                              IMapper mapper)
            : base(vehicleRepository, mapper)
        {
            _vehicleTypeRepository = vehicleTypeRepository;
        }

        public override async Task<VehicleDto> GetById(int id)
        {
            var vehicle = await base.GetById(id);
            var type = await _vehicleTypeRepository.GetById(vehicle.VehicleTypeId);
            vehicle.VehicleType = _mapper.Map<VehicleTypeDto>(type);
            return vehicle;
        }
    }
}
