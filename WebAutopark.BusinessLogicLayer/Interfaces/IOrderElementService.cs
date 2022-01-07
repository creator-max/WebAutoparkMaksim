using System.Collections.Generic;
using System.Threading.Tasks;
using WebAutopark.BusinessLogicLayer.DataTransferObjects;

namespace WebAutopark.BusinessLogicLayer.Interfaces
{
    public interface IOrderElementService : IDataService<OrderElementDto>
    {
        Task<IEnumerable<OrderElementDto>> GetAll(int orderId);
    }
}