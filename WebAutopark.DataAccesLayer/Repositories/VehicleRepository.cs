using Dapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAutopark.DataAccesLayer.Entities;
using WebAutopark.DataAccesLayer.Interfaces;

namespace WebAutopark.DataAccesLayer.Repositories
{
    public class VehicleRepository : BaseRepository, IRepository<Vehicle>
    {
        private const string QueryGetAll = "SELECT * FROM Vehicles ";

        private const string QueryGetById = "SELECT * FROM Vehicles " +
                                             "WHERE VehicleId = @VehicleId ";

        private const string QueryCreate = "INSERT INTO Vehicles (VehicleTypeId, Model, " +
                                            "YearOfIssue, Weight, TankCapacity, LicensePlat, " +
                                            "Mileage, Color, Price, ImageLink) " +
                                            "VALUES(@VehicleTypeId, @Model, @YearOfIssue, " +
                                            "@Weight, @TankCapacity, @LicensePlat, " +
                                            "@Mileage, @Color, @Price, @ImageLink)";

        private const string QueryDelete = "DELETE FROM Vehicles " +
                                            "WHERE VehicleId = @VehicleId ";

        private const string QueryUpdate = "UPDATE Vehicles SET " +
                                            "VehicleTypeId = @VehicleTypeId, " +
                                            "Model         = @Model, " +
                                            "YearOfIssue   = @YearOfIssue, " +
                                            "Weight        = @Weight, " +
                                            "TankCapacity  = @TankCapacity, " +
                                            "LicensePlat   = @LicensePlat, " +
                                            "Mileage       = @Mileage, " +
                                            "Color         = @Color," +
                                            "ImageLink     = @ImageLink," +
                                            "Price         = @Price " +
                                            "WHERE VehicleId = @VehicleId ";

        public VehicleRepository(IConnectionStringProvider connectionStringProvider) :
            base(connectionStringProvider)
        { }

        public async Task Create(Vehicle item)
            => await Connection.ExecuteAsync(QueryCreate, item);

        public async Task Delete(int id) 
            => await Connection.ExecuteAsync(QueryDelete, new { VehicleId = id});

        public async Task<IEnumerable<Vehicle>> GetAll() 
            => await Connection.QueryAsync<Vehicle>(QueryGetAll);

        public async Task<Vehicle> GetById(int id)
            => await Connection.QueryFirstOrDefaultAsync<Vehicle>(QueryGetById, new { VehicleId = id });

        public async Task Update(Vehicle item) 
            => await Connection.ExecuteAsync(QueryUpdate, item);

    }
}
