using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebAutopark.DataAccesLayer.Entities;
using WebAutopark.DataAccesLayer.Interfaces;

namespace WebAutopark.Controllers
{
    public class VehicleTypeController : Controller
    {
        private IRepository<VehicleType> _vehicleTypeRepository;

        public VehicleTypeController(IRepository<VehicleType> typeRepository)
        {
            _vehicleTypeRepository = typeRepository;
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var typeList = await _vehicleTypeRepository.GetAll();

            return View(typeList);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var item = await _vehicleTypeRepository.GetById(id);
            if (item != null)
                return View(item);
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(VehicleType vehicleType)
        {
            await _vehicleTypeRepository.Update(vehicleType);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int id)
        {
            var item = await _vehicleTypeRepository.GetById(id);
            if (item != null)
                return View(item);
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _vehicleTypeRepository.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Create(VehicleType type)
        {
            await _vehicleTypeRepository.Create(type);

            return RedirectToAction("Index");
        }
    }
}
