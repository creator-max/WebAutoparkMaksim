using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebAutopark.DataAccesLayer.Entities;
using WebAutopark.DataAccesLayer.Interfaces;

namespace WebAutopark.Controllers
{
    public class DetailController : Controller
    {
        private IRepository<Detail> _detailRepository;

        public DetailController(IRepository<Detail> repository)
        {
            _detailRepository = repository;
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var detailList = await _detailRepository.GetAll();

            return View(detailList);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var item = await _detailRepository.GetById(id);
            if (item != null)
                return View(item);
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Detail detail)
        {
            await _detailRepository.Update(detail);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int id)
        {
            var item = await _detailRepository.GetById(id);
            if (item != null)
                return View(item);
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _detailRepository.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Create(Detail detail)
        {
            await _detailRepository.Create(detail);

            return RedirectToAction("Index");
        }
    }
}
