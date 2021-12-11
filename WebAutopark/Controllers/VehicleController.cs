using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAutopark.DataAccesLayer.Entities;
using WebAutopark.DataAccesLayer.Interfaces;

namespace WebAutopark.Controllers
{
    public class VehicleController : Controller
    {
        private IRepository<Vehicle> _vehicleRepository;

        public VehicleController(IRepository<Vehicle> repository)
        {
            _vehicleRepository = repository;
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var vehicleList = await _vehicleRepository.GetAll();

            return View(vehicleList);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Vehicle vehicle)
        {
            await _vehicleRepository.Create(vehicle);

            return RedirectToAction("Index");
        }
    }
}
