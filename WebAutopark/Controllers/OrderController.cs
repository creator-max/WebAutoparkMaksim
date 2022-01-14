using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using WebAutopark.BusinessLogicLayer.Interfaces;
using WebAutopark.Models;

namespace WebAutopark.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderDtoService;
        private readonly IOrderElementService _orderElementDtoService;
        private readonly IMapper _mapper;

        public OrderController(IOrderService orderDtoService,
                               IOrderElementService orderElementDtoService,
                               IMapper mapper)
        {
            _orderDtoService = orderDtoService;
            _orderElementDtoService = orderElementDtoService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var ordersDto = await _orderDtoService.GetAll();
            var ordersView = _mapper.Map<List<OrderViewModel>>(ordersDto);

            return View(ordersView);
        }


        [HttpGet]
        public async Task<IActionResult> Create(int vehicleId)
        {
            var order = await _orderDtoService.CreateAndReturn(vehicleId);

            return RedirectToAction("Create", "OrderElement", new { orderId = order.OrderId });
        }

        [HttpGet]
        public async Task<IActionResult> ConfirmDelete(int orderId)
        {
            var orderDto = await _orderDtoService.GetById(orderId);

            if (orderDto != null)
            {
                var orderView = _mapper.Map<OrderViewModel>(orderDto);
                return View(orderView);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int orderId)
        {
            await _orderDtoService.Delete(orderId);

            return RedirectToAction(nameof(Index));
        }
    }
}
