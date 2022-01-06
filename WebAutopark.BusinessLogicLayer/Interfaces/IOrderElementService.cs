using System.Collections.Generic;
using System.Threading.Tasks;
using WebAutopark.BusinessLogicLayer.DataTransferObjects;

namespace WebAutopark.BusinessLogicLayer.Interfaces
{
    public interface IOrderElementService : IDtoService<OrderElementDTO>
    {
        Task<IEnumerable<OrderElementDTO>> GetAll(int orderId);
    }
}