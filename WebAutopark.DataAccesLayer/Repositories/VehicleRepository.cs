using Dapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAutopark.DataAccesLayer.Entities;
using WebAutopark.DataAccesLayer.Interfaces;
using System.Linq;
using WebAutopark.Core.Enums;

namespace WebAutopark.DataAccesLayer.Repositories
{
    public class VehicleRepository : BaseRepository, IVehicleRepository
    {
        private const string QueryGetAll = "SELECT * FROM [Vehicles] AS [V] " +
                                           "INNER JOIN [VehicleTypes] AS [VT] " +
                                           "ON [V].[VehicleTypeId] = [VT].[TypeId] ";

        private const string QueryGetById = "SELECT * FROM [Vehicles] AS [V] " +
                                            "INNER JOIN [VehicleTypes] AS [VT] " +
                                            "ON [V].[VehicleTypeId] = [VT].[TypeId] " +
                                            "WHERE [V].[VehicleId] = @VehicleId ";

        private const string QueryCreate = "INSERT INTO Vehicles (VehicleTypeId, Model, " +
                                            "YearOfIssue, Weight, TankCapacity, LicensePlat, " +
                                            "Mileage, Color, Price, ImageLink, FuelConsumption) " +
                                            "VALUES(@VehicleTypeId, @Model, @YearOfIssue, " +
                                            "@Weight, @TankCapacity, @LicensePlate, " +
                                            "@Mileage, @Color, @Price, @ImageLink, @FuelConsumption)";

        private const string QueryDelete = "DELETE FROM Vehicles " +
                                            "WHERE VehicleId = @VehicleId ";

        private const string QueryUpdate = "UPDATE Vehicles SET " +
                                            "VehicleTypeId   = @VehicleTypeId, " +
                                            "Model           = @Model, " +
                                            "YearOfIssue     = @YearOfIssue, " +
                                            "Weight          = @Weight, " +
                                            "TankCapacity    = @TankCapacity, " +
                                            "LicensePlat     = @LicensePlate, " +
                                            "Mileage         = @Mileage, " +
                                            "Color           = @Color," +
                                            "ImageLink       = @ImageLink," +
                                            "Price           = @Price," +
                                            "FuelConsumption = @FuelConsumption " +
                                            "WHERE VehicleId = @VehicleId ";

        public VehicleRepository(IConnectionStringProvider connectionStringProvider) :
            base(connectionStringProvider)
        { }

        public async Task Create(Vehicle item)
            => await Connection.ExecuteAsync(QueryCreate, item);

        public async Task Delete(int id) 
            => await Connection.ExecuteAsync(QueryDelete, new { VehicleId = id});

        public async Task<IEnumerable<Vehicle>> GetAll()
        {
            return await GetAll(SortOrder.IdAsc);
        }

        public async Task<IEnumerable<Vehicle>> GetAll(SortOrder sortOrder)
        {
            var query = QueryGetAll + GetSortQuery(sortOrder);

            return await Connection.QueryAsync<Vehicle, VehicleType, Vehicle>(query,
                (vehicle, vehicleType) =>
                {
                    vehicle.VehicleType = vehicleType;
                    return vehicle;
                },
                splitOn: "TypeId");
        }

        public async Task<Vehicle> GetById(int id)
        {
            var vehicles = await Connection.QueryAsync<Vehicle, VehicleType, Vehicle>(QueryGetById,
                (vehicle, vehicleType) =>
                {
                    vehicle.VehicleType = vehicleType;
                    return vehicle;
                },
                splitOn: "TypeId",
                param: new { VehicleId = id});

            return vehicles.FirstOrDefault();
        }

        public async Task Update(Vehicle item) 
            => await Connection.ExecuteAsync(QueryUpdate, item);

        private static string GetSortQuery(SortOrder sortOrder)
        {
            return sortOrder switch
            {
                SortOrder.IdAsc => " ORDER BY [V].[VehicleId] ASC ",
                SortOrder.TypeAsc => " ORDER BY [V].[VehicleTypeId] ASC ",
                SortOrder.TypeDesc => " ORDER BY [V].[VehicleTypeId] DESC ",
                SortOrder.MileageAsc => " ORDER BY [V].[Mileage] ASC ",
                SortOrder.MileageDesc => " ORDER BY [V].[Mileage] DESC ",
                SortOrder.ModelAsc => " ORDER BY [V].[Model] ASC ",
                SortOrder.ModelDesc => " ORDER BY [V].[Model] DESC ",
                _ => ""
            };
        }
    }
}
