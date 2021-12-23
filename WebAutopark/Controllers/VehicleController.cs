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
            var vehicleList = await _vehicleDtoService.GetAll();
            return View(_mapper.Map<List<VehicleViewModel>>(vehicleList));
        }

        [HttpPost]
        public async Task<IActionResult> Index(string name)
        {
            if (name != null)
            {
                name = name.ToUpper();
                var vehicles = await _vehicleDtoService.GetAll();
                vehicles = vehicles.Where(v => v.Model.ToUpper().Contains(name));
                return View(_mapper.Map<List<VehicleViewModel>>(vehicles));
            }
            return RedirectToAction("Index");
        }

        //CREATE
        public async Task<IActionResult> Create()
        {
            ViewBag.Colors = Enum.GetValues(typeof(Color)).Cast<Color>();
            ViewBag.Types = await _vehicleTypeDtoService.GetAll();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(VehicleViewModel vehicleViewModel)
        {
            await _vehicleDtoService.Create(
                _mapper.Map<VehicleDto>(vehicleViewModel));

            return RedirectToAction("Index");
        }

        //DELETE
        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int id)
        {
            var itemDto = await _vehicleDtoService.GetById(id);
            if (itemDto != null)
                return View(_mapper.Map<VehicleViewModel>(itemDto));

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
            var item = await _vehicleDtoService.GetById(id);
            if (item != null)
            {
                ViewBag.Colors = Enum.GetValues(typeof(Color)).Cast<Color>();
                ViewBag.Types = await _vehicleTypeDtoService.GetAll();
                return View(_mapper.Map<VehicleViewModel>(item));
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(VehicleViewModel vehicleViewModel)
        {
            await _vehicleDtoService.Update(
                _mapper.Map<VehicleDto>(vehicleViewModel));

            return RedirectToAction("Index");
        }


        //SOME OTHER LOGIC
        [HttpGet]
        public async Task<IActionResult> GetInformation(int id)
        {
            if (id >= 0)
            {
                var vehicle = await _vehicleDtoService.GetById(id);
                if (vehicle != null)
                {
                    return View(_mapper.Map<VehicleViewModel>(vehicle));
                }
            }

            return RedirectToAction("Index", "Vehicle");
        }
    }
}
