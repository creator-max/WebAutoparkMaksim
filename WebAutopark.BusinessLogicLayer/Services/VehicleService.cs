using WebAutopark.BusinessLogicLayer.Services.Base;
using WebAutopark.BusinessLogicLayer.DataTransferObjects;
using WebAutopark.DataAccesLayer.Entities;
using WebAutopark.DataAccesLayer.Interfaces;
using AutoMapper;
using System.Threading.Tasks;
using System.Collections.Generic;
using WebAutopark.BusinessLogicLayer.Services.Enums;
using System.Linq;
using WebAutopark.BusinessLogicLayer.Interfaces;
using WebAutopark.BusinessLogicLayer.Extensions;

namespace WebAutopark.BusinessLogicLayer.Services
{
    public class VehicleService : BaseService<VehicleDTO, Vehicle>, IVehicleService
    {
        private readonly IDtoService<VehicleTypeDTO> _vehicleTypeService;

        public VehicleService(IRepository<Vehicle> vehicleRepository,
                              IDtoService<VehicleTypeDTO> vehicleTypeService,
                              IMapper mapper)

            : base(vehicleRepository, mapper)
        {
            _vehicleTypeService = vehicleTypeService;
        }

        public override async Task<VehicleDTO> GetById(int id)
        {
            var vehicle = await base.GetById(id);
            var type = await _vehicleTypeService.GetById(vehicle.VehicleTypeId);

            vehicle.VehicleType = type;
            return vehicle;
        }

        public override async Task<IEnumerable<VehicleDTO>> GetAll()
        {
            var vehicles = await base.GetAll() as List<VehicleDTO>;
            var vehicleTypes = await _vehicleTypeService.GetAll() as List<VehicleTypeDTO>;

            vehicles.ForEach(v => v.VehicleType = vehicleTypes
                    .FirstOrDefault(t => t.TypeId == v.VehicleTypeId));

            return vehicles;
        }

        public async Task<IEnumerable<VehicleDTO>> GetAll(SortOrder sortOrder)
        {
            var vehicles = await GetAll();
            return vehicles.SortVehiclesBy(sortOrder);
        }
    }
}