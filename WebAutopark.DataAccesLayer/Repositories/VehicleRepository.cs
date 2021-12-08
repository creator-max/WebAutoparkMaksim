using Dapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAutopark.DataAccesLayer.Entities;
using WebAutopark.DataAccesLayer.Interfaces;

namespace WebAutopark.DataAccesLayer.Repositories
{
    public class VehicleRepository : BaseRepository<Vehicle>, IRepository<Vehicle>
    {
        private const string QueryGetAll = "SELECT * FROM Vehicles";

        private const string QueryGetById = "SELECT * FROM Vehicles " +
                                             "WHERE VehicleId = @VehicleId";

        private const string QueryCreate = "INSERT Vehicles VALUES(" +
                                            "@VehicleTypeId, @Model, @YearOfIssue," +
                                            "@Weight, @TankCapacity, @LicensePlat, " +
                                            "@MileageKm, @Color)";

        private const string QueryDelete = "DELETE FROM Vehicles" +
                                            "WHERE VehicleId = @VehicleId";

        private const string QueryUpdate = "UPDATE Vehicles SET" +
                                            "VehicleTypeId = @VehicleTypeId," +
                                            "Model         = @Model," +
                                            "YearOfIssue   = @YearOfIssue," +
                                            "Weight        = @Weight," +
                                            "TankCapacity  = @TankCapacity," +
                                            "LicensePlat   = @LicensePlat," +
                                            "MileageKm     = @MileageKm, " +
                                            "Color         = @Color" +
                                            "WHERE VehicleId = @VehicleId";

        public VehicleRepository(string connectionString)
            : base(connectionString)
        { }

        public async Task CreateAsync(Vehicle item) => await Connection.ExecuteAsync(QueryCreate, item);
        public async Task DeleteAsync(int id) => await Connection.ExecuteAsync(QueryDelete, id);
        public async Task<IEnumerable<Vehicle>> GetAllAsync() => await Connection.QueryAsync<Vehicle>(QueryGetAll);
        public async Task<Vehicle> GetByIdAsync(int id) => await Connection.QueryFirstOrDefaultAsync<Vehicle>(QueryGetById, id);
        public async Task UpdateAsync(Vehicle item) => await Connection.ExecuteAsync(QueryUpdate, item);

    }
}
