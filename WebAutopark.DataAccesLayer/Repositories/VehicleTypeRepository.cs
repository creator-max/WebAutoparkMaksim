using WebAutopark.DataAccesLayer.Entities;

namespace WebAutopark.DataAccesLayer.Repositories
{
    public class VehicleTypeRepository : BaseRepository<VehicleType>
    {
        private const string _queryGetAll = "SELECT * FROM VehicleTypes";

        private const string _queryGetById = "SELECT * FROM VehicleTypes " +
                                             "WHERE TypeId = @VehicleTypeId";

        private const string _queryCreate = "INSERT VehicleTypes VALUES(" +
                                            "@VehicleTypeName, @TaxCoefficient)";

        private const string _queryDelete = "DELETE FROM VehicleTypes" +
                                            "WHERE TypeId = @VehicleTypeId";

        private const string _queryUpdate = "UPDATE VehicleTypes SET" +
                                            "TypeName       = @VehicleId," +
                                            "TaxCoefficient = @TaxCoefficient," +
                                            "WHERE TypeId = @VehicleTypeId";
        public VehicleTypeRepository(string connectionString) : 
            base(connectionString, _queryGetAll, 
                 _queryGetById, _queryCreate, 
                 _queryDelete, _queryUpdate)
        { }
    }
}
