using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using WebAutopark.BusinessLogicLayer.DataTransferObjects;
using WebAutopark.BusinessLogicLayer.Interfaces;
using WebAutopark.Models;
using System;
using System.Linq;

namespace WebAutopark.Controllers
{
    public class VehicleController : Controller
    {
        private readonly IDtoService<VehicleDto> _vehicleDtoService;
        private readonly IDtoService<VehicleTypeDto> _vehicleTypeDtoService;
        private readonly IMapper _mapper;

        public VehicleController(IDtoService<VehicleDto> vehicleDtoService,
                                 IDtoService<VehicleTypeDto> vehicleTypeDtoService,
                                 IMapper mapper)
        {
            _vehicleDtoService = vehicleDtoService;
            _vehicleTypeDtoService = vehicleTypeDtoService;
            _mapper = mapper;
        }

        //GETALL
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var vehiclesDto = await _vehicleDtoService.GetAll();
            var vehiclesView = _mapper.Map<List<VehicleViewModel>>(vehiclesDto);

            return View(vehiclesView);
        }

        [HttpPost]
        public async Task<IActionResult> Index(string name)
        {
            if (name != null)
            {
                var vehiclesDto = await _vehicleDtoService.GetAll();
                vehiclesDto = vehiclesDto.Where(v => v.Model
                    .Equals(name, StringComparison.OrdinalIgnoreCase));

                var vehiclesView = _mapper.Map<List<VehicleViewModel>>(vehiclesDto);
                return View(vehiclesView);
            }
            return RedirectToAction("Index");
        }

        //CREATE
        public async Task<IActionResult> Create()
        {
            ViewBag.Colors = Enum.GetValues(typeof(Color))
                                 .Cast<Color>();

            ViewBag.Types = await _vehicleTypeDtoService.GetAll();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(VehicleViewModel vehicleViewModel)
        {
            if (ModelState.IsValid)
            {
                var vehicleDto = _mapper.Map<VehicleDto>(vehicleViewModel);
                await _vehicleDtoService.Create(vehicleDto);
            }
            return RedirectToAction("Index");
        }

        //DELETE
        [HttpGet]
        [ActionName("Delete")]
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
            return RedirectToAction("Index");
        }

        //UPDATE
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
                var vehicleDto = _mapper.Map<VehicleDto>(vehicleViewModel);
                await _vehicleDtoService.Update(vehicleDto);
            }
            return RedirectToAction("Index");
        }
    }
}
