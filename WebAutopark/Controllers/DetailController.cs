using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using WebAutopark.BusinessLogicLayer.DataTransferObjects;
using WebAutopark.BusinessLogicLayer.Interfaces;
using WebAutopark.Models;

namespace WebAutopark.Controllers
{
    public class DetailController : Controller
    {
        private readonly IDtoService<DetailDto> _detailDtoService;
        private readonly IMapper _mapper;

        public DetailController(IDtoService<DetailDto> dtoService, 
                                IMapper mapper)
        {
            _detailDtoService = dtoService;
            _mapper = mapper;
        }


        //GETALL
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var detailsDto = await _detailDtoService.GetAll();
            return View(_mapper.Map<List<DetailViewModel>>(detailsDto));
        }

        //CREATE
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(DetailViewModel detailViewModel)
        {
            await _detailDtoService.Create(
                _mapper.Map<DetailDto>(detailViewModel));

            return RedirectToAction("Index");
        }

        //UPDATE
        public async Task<IActionResult> Edit(int id)
        {
            var item = await _detailDtoService.GetById(id);
            if (item != null)
                return View(_mapper.Map<DetailViewModel>(item));
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(DetailViewModel detailViewModel)
        {
            await _detailDtoService.Update(
                _mapper.Map<DetailDto>(detailViewModel));

            return RedirectToAction("Index");
        }

        //DELETE
        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int id)
        {
            var itemDto = await _detailDtoService.GetById(id);
            if (itemDto != null)
                return View(_mapper.Map<DetailViewModel>(itemDto));

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _detailDtoService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
