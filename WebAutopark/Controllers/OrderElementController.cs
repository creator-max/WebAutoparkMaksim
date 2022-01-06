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
        private readonly IDtoService<DetailDTO> _detailService;

        public OrderElementController(IOrderElementService orderElementService,
                                      IDtoService<DetailDTO> detailService,
                                      IMapper mapper)
        {
            _orderElementDtoService = orderElementService;
            _mapper = mapper;
            _detailService = detailService;
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
        public async Task<IActionResult> Create(OrderElementViewModel orderElementView)
        {
            if (ModelState.IsValid)
            {
                var orderElementDto = _mapper.Map<OrderElementDTO>(orderElementView);
                await _orderElementDtoService.Create(orderElementDto);
            }

            return RedirectToAction("ChangeOrderElements", "Order", new { orderId = orderElementView.OrderId });
        }
    }
}
