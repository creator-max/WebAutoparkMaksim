using System.Threading.Tasks;
using WebAutopark.BusinessLogicLayer.DataTransferObjects;

namespace WebAutopark.BusinessLogicLayer.Interfaces
{
    public interface IOrderService : IDtoService<OrderDTO>
    {
        Task<OrderDTO> CreateAndReturn(int vehicleId);
    }
}
