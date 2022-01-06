using WebAutopark.BusinessLogicLayer.Services.Base;
using WebAutopark.BusinessLogicLayer.DataTransferObjects;
using WebAutopark.BusinessLogicLayer.Interfaces;
using WebAutopark.DataAccesLayer.Entities;
using WebAutopark.DataAccesLayer.Interfaces;
using AutoMapper;
using System.Threading.Tasks;

namespace WebAutopark.BusinessLogicLayer.Services
{
    public class OrderService : BaseService<OrderDTO, Order>, IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository,
                            IMapper mapper) 
            : base(orderRepository, mapper)
        {
            _orderRepository = orderRepository;
        }

        public async Task<OrderDTO> CreateAndReturn(int vehicleId)
        {
            var order = await _orderRepository.CreateAndReturn(vehicleId);
            return _mapper.Map<OrderDTO>(order);
        }
    }
}
