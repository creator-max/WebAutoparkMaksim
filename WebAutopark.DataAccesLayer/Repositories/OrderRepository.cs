using Dapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAutopark.DataAccesLayer.Entities;
using WebAutopark.DataAccesLayer.Interfaces;

namespace WebAutopark.DataAccesLayer.Repositories
{
    public class OrderRepository : BaseRepository, IOrderRepository
    {
        private const string QueryGetAll = "SELECT * FROM Orders ";

        private const string QueryGetById = "SELECT * FROM Orders " +
                                            "WHERE OrderId = @OrderId";

        private const string QueryCreate = "INSERT INTO Orders(VehicleId) " +
                                            "VALUES(@VehicleId)";

        private const string QueryCreateAndReturn = "INSERT INTO Orders(VehicleId)" +
                                                    " OUTPUT Inserted.OrderId," +
                                                    "        Inserted.VehicleId " +
                                                    "VALUES(@VehicleId)";

        private const string QueryDelete = "DELETE FROM Orders " +
                                           "WHERE OrderId = @OrderId";

        private const string QueryUpdate = "UPDATE Orders SET " +
                                           "VehicleId = @VehicleId " +
                                           "WHERE OrderId = @OrderId";

        public OrderRepository(IConnectionStringProvider connectionStringProvider)
            : base(connectionStringProvider)
        { }

        public async Task Create(Order item)
            => await Connection.ExecuteAsync(QueryCreate, item);

        public async Task<Order> CreateAndReturn(int vehicleId)
        {
            var order = new {
                VehicleId = vehicleId
            };

            return await Connection.QueryFirstOrDefaultAsync<Order>(QueryCreateAndReturn, order);
        }

        public async Task Delete(int id)
            => await Connection.ExecuteAsync(QueryDelete, new { OrderId = id });

        public async Task<IEnumerable<Order>> GetAll() 
            => await Connection.QueryAsync<Order>(QueryGetAll);

        public async Task<Order> GetById(int id)
            => await Connection.QueryFirstOrDefaultAsync<Order>(QueryGetById, new { OrderId = id });

        public async Task Update(Order item) 
            => await Connection.ExecuteAsync(QueryUpdate, item);
    }
}
