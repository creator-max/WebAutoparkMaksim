using System.Collections.Generic;
using System.Linq;
using WebAutopark.BusinessLogicLayer.DataTransferObjects;
using WebAutopark.BusinessLogicLayer.Services.Enums;

namespace WebAutopark.BusinessLogicLayer.Extensions
{
    public static class IEnumerableExtensions
    {
        public static IEnumerable<VehicleDTO> SortVehiclesBy(this IEnumerable<VehicleDTO> vehicles, SortOrder sortOrder)
        {
            vehicles = sortOrder switch
            {
                SortOrder.ModelAsc => vehicles.OrderBy(s => s.Model),
                SortOrder.ModelDesc => vehicles.OrderByDescending(s => s.Model),
                SortOrder.MileageAsc => vehicles.OrderBy(s => s.Mileage),
                SortOrder.MileageDesc => vehicles.OrderByDescending(s => s.Mileage),
                SortOrder.TypeAsc => vehicles.OrderBy(s => s.VehicleTypeId),
                SortOrder.TypeDesc => vehicles.OrderByDescending(s => s.VehicleTypeId),
                _ => vehicles.OrderBy(s => s.VehicleId)
            };

            return vehicles;
        }
    }
}
