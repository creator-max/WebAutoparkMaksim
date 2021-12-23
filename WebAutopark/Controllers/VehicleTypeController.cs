using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using WebAutopark.BusinessLogicLayer.DataTransferObjects;
using WebAutopark.BusinessLogicLayer.Interfaces;
using WebAutopark.Models;

namespace WebAutopark.Controllers
{
    public class VehicleTypeController : Controller
    {
        private readonly IDtoService<VehicleTypeDto> _vehicleTypeDtoService;
        private readonly IMapper _mapper;

        public VehicleTypeController(IDtoService<VehicleTypeDto> dtoService,
                                     IMapper mapper)
        {
            _vehicleTypeDtoService = dtoService;
            _mapper = mapper;
        }


        //GETALL
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var vehicleTypesDto = await _vehicleTypeDtoService.GetAll();
            return View(_mapper.Map<List<VehicleTypeViewModel>>(vehicleTypesDto));
        }

        //CREATE
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(VehicleTypeViewModel vehicleTypeViewModel)
        {
            await _vehicleTypeDtoService.Create(
                _mapper.Map<VehicleTypeDto>(vehicleTypeViewModel));

            return RedirectToAction("Index");
        }

        //UPDATE
        public async Task<IActionResult> Edit(int id)
        {
            var item = await _vehicleTypeDtoService.GetById(id);
            if (item != null)
                return View(_mapper.Map<VehicleTypeViewModel>(item));
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(VehicleTypeViewModel vehicleTypeViewModel)
        {
            await _vehicleTypeDtoService.Update(
                _mapper.Map<VehicleTypeDto>(vehicleTypeViewModel));

            return RedirectToAction("Index");
        }

        //DELETE
        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int id)
        {
            var itemDto = await _vehicleTypeDtoService.GetById(id);
            if (itemDto != null)
                return View(_mapper.Map<VehicleTypeViewModel>(itemDto));

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _vehicleTypeDtoService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
