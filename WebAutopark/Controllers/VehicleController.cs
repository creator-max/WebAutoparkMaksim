using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using WebAutopark.BusinessLogicLayer.DataTransferObjects;
using WebAutopark.BusinessLogicLayer.Interfaces;
using WebAutopark.Models;
using System;
using System.Linq;
using WebAutopark.BusinessLogicLayer.Services.Enums;


namespace WebAutopark.Controllers
{
    public class VehicleController : Controller
    {
        private readonly IVehicleService _vehicleDtoService;
        private readonly IDtoService<VehicleTypeDTO> _vehicleTypeDtoService;
        private readonly IMapper _mapper;

        public VehicleController(IVehicleService vehicleDtoService,
                                 IDtoService<VehicleTypeDTO> vehicleTypeDtoService,
                                 IMapper mapper)
        {
            _vehicleDtoService = vehicleDtoService;
            _vehicleTypeDtoService = vehicleTypeDtoService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string searchName, SortOrder sortOrder)
        {
            ViewBag.SortByModel = sortOrder == SortOrder.ModelAsc ? SortOrder.ModelDesc : SortOrder.ModelAsc;
            ViewBag.SortByMileage = sortOrder == SortOrder.MileageAsc ? SortOrder.MileageDesc : SortOrder.MileageAsc;
            ViewBag.SortByType = sortOrder == SortOrder.TypeAsc ? SortOrder.TypeDesc : SortOrder.TypeAsc;

            ViewBag.CurrentSearchName = searchName;

            var vehiclesDto = await _vehicleDtoService.GetAll(sortOrder);

            if (!String.IsNullOrEmpty(searchName))
            {
                vehiclesDto = vehiclesDto.Where(v => v.Model
                    .Contains(searchName, StringComparison.OrdinalIgnoreCase));
            }

            var vehiclesView = _mapper.Map<List<VehicleViewModel>>(vehiclesDto);
            return View(vehiclesView);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Colors = Enum.GetValues(typeof(Color)).Cast<Color>();
            ViewBag.Types = await _vehicleTypeDtoService.GetAll();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(VehicleViewModel vehicleViewModel)
        {
            if (ModelState.IsValid)
            {
                var vehicleDto = _mapper.Map<VehicleDTO>(vehicleViewModel);
                await _vehicleDtoService.Create(vehicleDto);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> ConfirmDelete(int id)
        {
            var vehicleDto = await _vehicleDtoService.GetById(id);

            if (vehicleDto != null)
            {
                var vehicleView = _mapper.Map<VehicleViewModel>(vehicleDto);
                return View(vehicleView);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _vehicleDtoService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var vehicleDto = await _vehicleDtoService.GetById(id);

            if (vehicleDto != null)
            {
                ViewBag.Colors = Enum.GetValues(typeof(Color))
                                     .Cast<Color>();

                ViewBag.Types = await _vehicleTypeDtoService.GetAll();
                var vehicleView = _mapper.Map<VehicleViewModel>(vehicleDto);
                return View(vehicleView);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(VehicleViewModel vehicleViewModel)
        {
            if (ModelState.IsValid)
            {
                var vehicleDto = _mapper.Map<VehicleDTO>(vehicleViewModel);
                await _vehicleDtoService.Update(vehicleDto);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Information(int id)
        {
            var vehicleDto = await _vehicleDtoService.GetById(id);
            var vehicleView = _mapper.Map<VehicleViewModel>(vehicleDto);

            return View(vehicleView);
        }
    }
}
