using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAutopark.DataAccesLayer.Entities;
using WebAutopark.DataAccesLayer.Interfaces;
using WebAutopark.Models;

namespace WebAutopark.Controllers
{
    public class HomeController : Controller
    {
        private IRepository<Vehicle> _vehicleRepository;

        public HomeController(IRepository<Vehicle> vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        public async Task<IActionResult> Index()
        {
            var vehicles = await _vehicleRepository.GetAll();
            return View(vehicles);
        }

        [HttpPost]
        public async Task<IActionResult> Index(string name)
        {
            if (name != null)
            {
                name = name.ToUpper();
                var vehicles = await _vehicleRepository.GetAll();
                vehicles = vehicles.Where(v => v.Model.ToUpper().Contains(name));
                return View(vehicles);
            }
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });
        }
    }
}