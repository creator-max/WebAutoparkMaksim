using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAutopark.DataAccesLayer.Entities;
using WebAutopark.DataAccesLayer.Interfaces;
using WebAutopark.Models;

namespace WebAutopark.Controllers
{
    public class VehicleController : Controller
    {
        private IRepository<Vehicle> _vehicleRepository;
        private IRepository<VehicleType> _vehicleTypeRepository;
        public static List<VehicleType> VehicleTypes;

        public VehicleController(IRepository<Vehicle> repository, IRepository<VehicleType> typeRepo)
        {
            _vehicleRepository = repository;
            _vehicleTypeRepository = typeRepo;
        }

        //GETALL
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var vehicleList = await _vehicleRepository.GetAll();
            var vehicleTypes = await _vehicleTypeRepository.GetAll();
            VehicleTypes = vehicleTypes.ToList();
            return View(vehicleList);
        }

        //CREATE
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Vehicle vehicle)
        {

            if (ModelState.IsValid)
            {
                await _vehicleRepository.Create(vehicle);
                return RedirectToAction("Index");
            }
            return View();
        }

        //DELETE
        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int id)
        {
            var item = await _vehicleRepository.GetById(id);
            if (item != null)
                return View(item);
            return NotFound();
        }

        [HttpPost]
        public async Task<RedirectToActionResult> Delete(int id)
        {
            await _vehicleRepository.Delete(id);
            return RedirectToAction("Index");
        }

        //UPDATE
        public async Task<IActionResult> Edit(int id)
        {
            var item = await _vehicleRepository.GetById(id);
            if (item != null)
                return View(item);
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                await _vehicleRepository.Update(vehicle);
            }
            return View(vehicle);
        }

        [HttpGet]
        public async Task<IActionResult> GetInformation(int id)
        {
            if(id >= 0)
            {
                var vehicle = await _vehicleRepository.GetById(id);
                if (vehicle != null)
                {
                    var type = await _vehicleTypeRepository.GetById(vehicle.VehicleTypeId);
                    vehicle.VehicleType = type;
                    return View(vehicle);
                }
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
