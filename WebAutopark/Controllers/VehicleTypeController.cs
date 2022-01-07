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
        private readonly IDataService<VehicleTypeDto> _vehicleTypeDtoService;
        private readonly IMapper _mapper;

        public VehicleTypeController(IDataService<VehicleTypeDto> dtoService, IMapper mapper)
        {
            _vehicleTypeDtoService = dtoService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var vehicleTypesDto = await _vehicleTypeDtoService.GetAll();
            var vehicleTypesView = _mapper.Map<List<VehicleTypeViewModel>>(vehicleTypesDto);
            return View(vehicleTypesView);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(VehicleTypeViewModel vehicleTypeViewModel)
        {
            if (ModelState.IsValid)
            {
                var vehicletypeDto = _mapper.Map<VehicleTypeDto>(vehicleTypeViewModel);
                await _vehicleTypeDtoService.Create(vehicletypeDto);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var vehicleType = await _vehicleTypeDtoService.GetById(id);

            if (vehicleType != null)
            {
                var vehicleTypeView = _mapper.Map<VehicleTypeViewModel>(vehicleType);
                return View(vehicleTypeView);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(VehicleTypeViewModel vehicleTypeViewModel)
        {
            if (ModelState.IsValid)
            {
                var vehicleTypeDto = _mapper.Map<VehicleTypeDto>(vehicleTypeViewModel);
                await _vehicleTypeDtoService.Update(vehicleTypeDto);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> ConfirmDelete(int id)
        {
            var vehicleTypeDto = await _vehicleTypeDtoService.GetById(id);

            if (vehicleTypeDto != null)
            {
                var vehicleTypeView = _mapper.Map<VehicleTypeViewModel>(vehicleTypeDto);
                return View(vehicleTypeView);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _vehicleTypeDtoService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
