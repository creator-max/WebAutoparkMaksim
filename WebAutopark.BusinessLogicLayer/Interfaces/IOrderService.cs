using System.Threading.Tasks;
using WebAutopark.BusinessLogicLayer.DataTransferObjects;

namespace WebAutopark.BusinessLogicLayer.Interfaces
{
    public interface IOrderService : IDataService<OrderDto>
    {
        Task<OrderDto> CreateAndReturn(int vehicleId);
    }
}
