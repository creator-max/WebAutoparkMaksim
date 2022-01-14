using Dapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAutopark.DataAccesLayer.Entities;
using WebAutopark.DataAccesLayer.Interfaces;

namespace WebAutopark.DataAccesLayer.Repositories
{
    public class OrderElementRepository : BaseRepository, IRepository<OrderElement>
    {
        private const string QueryGetAll = "SELECT * FROM [OrderElements] AS [OE] " +
                                           "INNER JOIN [Details] AS [D] " +
                                           "ON [OE].[DetailId] = [D].[DetailId]";

        private const string QueryGetById = "SELECT * FROM [OrderElements] AS [OE] " +
                                           "INNER JOIN [Details] AS [D] " +
                                           "ON [OE].[DetailId] = [D].[DetailId] " +
                                           "WHERE [OE].[OrderElementId] = @OrderElementId";

        private const string QueryCreate = "INSERT INTO OrderElements(OrderId, DetailId, Quantity) " +
                                            "VALUES(@OrderId, @DetailId, @Quantity)";

        private const string QueryDelete = "DELETE FROM OrderElements " +
                                           "WHERE OrderElementId = @OrderElementId";

        private const string QueryUpdate = "UPDATE OrderElements SET " +
                                           "OrderId = @OrderId, " +
                                           "DetailId = @DetailId, " +
                                           "Quantity = @Quantity " +
                                           "WHERE OrderElementId = @OrderElementId";

        public OrderElementRepository(IConnectionStringProvider connectionStringProvider)
            : base(connectionStringProvider)
        { }

        public async Task Create(OrderElement item)
            => await Connection.ExecuteAsync(QueryCreate, item);

        public async Task Delete(int id)
            => await Connection.ExecuteAsync(QueryDelete, new { OrderElementId = id });

        public async Task<IEnumerable<OrderElement>> GetAll()
        {
            return await Connection.QueryAsync<OrderElement, Detail, OrderElement>(QueryGetAll,
                (orderElement, detail) =>
                {
                    orderElement.Detail = detail;
                    return orderElement;
                },
                splitOn: "DetailId");
        }

        public async Task<OrderElement> GetById(int id)
        {
            var orderElements = await Connection.QueryAsync<OrderElement, Detail, OrderElement>(QueryGetById,
                (orderElement, detail) =>
                {
                    orderElement.Detail = detail;
                    return orderElement;
                },
                splitOn: "DetailId",
                param: new { OrderElementId = id });

            return orderElements.FirstOrDefault();
        }

        public async Task Update(OrderElement item) 
            => await Connection.ExecuteAsync(QueryUpdate, item);
    }
}
