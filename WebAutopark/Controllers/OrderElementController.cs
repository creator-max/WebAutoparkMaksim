using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using WebAutopark.BusinessLogicLayer.Interfaces;
using WebAutopark.Models;
using WebAutopark.BusinessLogicLayer.DataTransferObjects;

namespace WebAutopark.Controllers
{
    public class OrderElementController : Controller
    {
        private readonly IOrderElementService _orderElementDtoService;
        private readonly IMapper _mapper;
        private readonly IDataService<DetailDto> _detailService;

        public OrderElementController(IOrderElementService orderElementService,
                                      IDataService<DetailDto> detailService,
                                      IMapper mapper)
        {
            _orderElementDtoService = orderElementService;
            _mapper = mapper;
            _detailService = detailService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int orderId)
        {
            var orderElements = await _orderElementDtoService.GetAll(orderId);
            var orderElementsView = _mapper.Map<List<OrderElementViewModel>>(orderElements);

            return View(orderElementsView);
        }

        [HttpGet]
        public async Task<IActionResult> Create(int orderId)
        {
            var orderElementView = new OrderElementViewModel { OrderId = orderId };
            var detailsDto = await _detailService.GetAll();
            var detailsView = _mapper.Map<List<DetailViewModel>>(detailsDto);

            ViewBag.Details = detailsView;

            return View(orderElementView);
        }

        [HttpPost]
        public async Task<IActionResult> Create(OrderElementViewModel orderElementView, bool createAnother)
        {
            if (ModelState.IsValid)
            {
                var orderElementDto = _mapper.Map<OrderElementDto>(orderElementView);
                await _orderElementDtoService.Create(orderElementDto);

                if (createAnother)
                    return RedirectToAction(nameof(Create), new { orderId = orderElementView.OrderId });
            }

            return RedirectToAction("ChangeOrderElements", "Order", new { orderId = orderElementView.OrderId });
        }
    }
}
