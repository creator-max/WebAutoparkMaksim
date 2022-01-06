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

            return RedirectToAction(nameof(ChangeOrderElements), new { orderId = order.OrderId });
        }

        [HttpGet]
        public async Task<IActionResult> ChangeOrderElements(int orderId)
        {
            var order = await _orderDtoService.GetById(orderId);
            var orderView = _mapper.Map<OrderViewModel>(order);

            var orderElements = await _orderElementDtoService.GetAll(orderView.OrderId);
            var orderElementsView = _mapper.Map<List<OrderElementViewModel>>(orderElements);

            orderView.OrderElements = orderElementsView;

            return View(orderView);
        }

        [HttpGet]
        public async Task<IActionResult> OrderInformation(int orderId)
        {
            var order = await _orderDtoService.GetById(orderId);
            var orderView = _mapper.Map<OrderViewModel>(order);

            var orderElements = await _orderElementDtoService.GetAll(orderView.OrderId);
            var orderElementsView = _mapper.Map<List<OrderElementViewModel>>(orderElements);

            orderView.OrderElements = orderElementsView;

            return View(orderView);
        }
    }
}
