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
    public class OrderElementService : BaseService<OrderElementDTO, OrderElement>, IOrderElementService
    {
        private readonly IDtoService<DetailDTO> _detailService;

        public OrderElementService(IRepository<OrderElement> orderElementRepository,
                                   IDtoService<DetailDTO> detailService,
                                   IMapper mapper) 
            : base(orderElementRepository, mapper)
        {
            _detailService = detailService;
        }

        public override async Task<OrderElementDTO> GetById(int id)
        {
            var order = await base.GetById(id);
            var detail = await _detailService.GetById(order.DetailId);

            order.Detail = detail;
            return order;
        }

        public override async Task<IEnumerable<OrderElementDTO>> GetAll()
        {
            var orderElements = await base.GetAll() as List<OrderElementDTO>;
            var details = await _detailService.GetAll() as List<DetailDTO>;

            orderElements.ForEach(oe => oe.Detail = details
                         .FirstOrDefault(d => d.DetailId == oe.DetailId));

            return orderElements;
        }

        public async Task<IEnumerable<OrderElementDTO>> GetAll(int orderId)
        {
            var orderElements = await GetAll();
            return orderElements.Where(e => e.OrderId == orderId);
        }
    }
}
