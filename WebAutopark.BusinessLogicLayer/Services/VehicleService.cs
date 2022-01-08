using WebAutopark.BusinessLogicLayer.Services.Base;
using WebAutopark.BusinessLogicLayer.DataTransferObjects;
using WebAutopark.DataAccesLayer.Entities;
using WebAutopark.DataAccesLayer.Interfaces;
using AutoMapper;
using System.Threading.Tasks;
using System.Collections.Generic;
using WebAutopark.BusinessLogicLayer.Services.Enums;
using WebAutopark.BusinessLogicLayer.Interfaces;
using WebAutopark.DataAccesLayer.Repositories.Enums;

namespace WebAutopark.BusinessLogicLayer.Services
{
    public class VehicleService : BaseService<VehicleDto, Vehicle>, IVehicleService
    {
        private readonly IVehicleRepository _vehicleRepository;

        public VehicleService(IVehicleRepository vehicleRepository, IMapper mapper)

            : base(vehicleRepository, mapper)
        { 
            _vehicleRepository = vehicleRepository;
        }

        public async Task<IEnumerable<VehicleDto>> GetAll(SortOrderDto sortOrderDto)
        {
            var sortOrder = _mapper.Map<SortOrder>(sortOrderDto);

            var vehicles = await _vehicleRepository.GetAll(sortOrder);
            var vehiclesDto = _mapper.Map<List<VehicleDto>>(vehicles);

            return vehiclesDto;
        }
    }
}