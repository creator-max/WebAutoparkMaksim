using System.Collections.Generic;
using System.Threading.Tasks;
using WebAutopark.BusinessLogicLayer.DataTransferObjects;
using WebAutopark.BusinessLogicLayer.Services.Enums;

namespace WebAutopark.BusinessLogicLayer.Interfaces
{
    public interface IVehicleService : IDtoService<VehicleDTO>
    {
        Task<IEnumerable<VehicleDTO>> GetAll(SortOrder sortOrder);
    }
}