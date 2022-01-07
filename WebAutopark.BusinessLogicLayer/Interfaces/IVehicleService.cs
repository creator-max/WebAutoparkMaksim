using System.Collections.Generic;
using System.Threading.Tasks;
using WebAutopark.BusinessLogicLayer.DataTransferObjects;
using WebAutopark.BusinessLogicLayer.Services.Enums;

namespace WebAutopark.BusinessLogicLayer.Interfaces
{
    public interface IVehicleService : IDataService<VehicleDto>
    {
        Task<IEnumerable<VehicleDto>> GetAll(SortOrderDto sortOrder);
    }
}