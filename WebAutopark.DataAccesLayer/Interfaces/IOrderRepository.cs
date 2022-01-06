using System.Threading.Tasks;
using WebAutopark.DataAccesLayer.Entities;

namespace WebAutopark.DataAccesLayer.Interfaces
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<Order> CreateAndReturn(int vehicleId);
    }
}
