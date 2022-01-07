using WebAutopark.BusinessLogicLayer.Services.Base;
using WebAutopark.BusinessLogicLayer.DataTransferObjects;
using WebAutopark.DataAccesLayer.Entities;
using WebAutopark.DataAccesLayer.Interfaces;
using AutoMapper;
using System.Threading.Tasks;
using WebAutopark.BusinessLogicLayer.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace WebAutopark.BusinessLogicLayer.Services
{
    public class OrderElementService : BaseService<OrderElementDto, OrderElement>, IOrderElementService
    {
        public OrderElementService(IRepository<OrderElement> orderElementRepository,
                                   IMapper mapper) 
            : base(orderElementRepository, mapper)
        { }

        public async Task<IEnumerable<OrderElementDto>> GetAll(int orderId)
        {
            var orderElements = await GetAll();
            return orderElements.Where(e => e.OrderId == orderId);
        }
    }
}
