using System;
using System.Collections.Generic;
using System.Linq;
using WebAutopark.DataAccesLayer.Entities;

namespace WebAutopark.DataAccesLayer.Repositories
{
    public class VehicleRepository : BaseRepository<Vehicle>
    {
        private const string _queryGetAll = "SELECT * FROM Vehicles";

        private const string _queryGetById = "SELECT * FROM Vehicles " +
                                             "WHERE VehicleId = @VehicleId";

        private const string _queryCreate = "INSERT Vehicles VALUES(" +
                                            "@VehicleTypeId, @Model, @YearOfIssue," +
                                            "@Weight, @TankCapacity, @LicensePlat, " +
                                            "@MileageKm, @Color)";

        private const string _queryDelete = "DELETE FROM Vehicles" +
                                            "WHERE VehicleId = @VehicleId";

        private const string _queryUpdate = "UPDATE Vehicles SET" +
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

            : base(connectionString, _queryGetAll, 
                  _queryGetById, _queryCreate, 
                  _queryDelete, _queryUpdate)
        { }
        
    }
}
