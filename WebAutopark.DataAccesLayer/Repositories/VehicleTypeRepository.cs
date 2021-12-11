using Dapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAutopark.DataAccesLayer.Entities;
using WebAutopark.DataAccesLayer.Interfaces;

namespace WebAutopark.DataAccesLayer.Repositories
{
    public class VehicleTypeRepository : BaseRepository, IRepository<VehicleType>
    {
        private const string QueryGetAll = "SELECT * FROM VehicleTypes";

        private const string QueryGetById = "SELECT * FROM VehicleTypes " +
                                             "WHERE TypeId = @VehicleTypeId";

        private const string QueryCreate = "INSERT INTO VehicleTypes VALUES(" +
                                            "@VehicleTypeName, @TaxCoefficient)";

        private const string QueryDelete = "DELETE FROM VehicleTypes" +
                                            "WHERE TypeId = @VehicleTypeId";

        private const string QueryUpdate = "UPDATE VehicleTypes SET" +
                                            "TypeName       = @VehicleId," +
                                            "TaxCoefficient = @TaxCoefficient" +
                                            "WHERE TypeId = @VehicleTypeId";

        public VehicleTypeRepository(IConnectionStringProvider connectionStringProvider) :
            base(connectionStringProvider)
        { }

        public async Task Create(VehicleType item) => await Connection.ExecuteAsync(QueryCreate, item);
        public async Task Delete(int id) => await Connection.ExecuteAsync(QueryDelete, id);
        public async Task<IEnumerable<VehicleType>> GetAll() => await Connection.QueryAsync<VehicleType>(QueryGetAll);
        public async Task<VehicleType> GetById(int id) => await Connection.QueryFirstOrDefaultAsync<VehicleType>(QueryGetById, id);
        public async Task Update(VehicleType item) => await Connection.ExecuteAsync(QueryUpdate, item);
    }
}
