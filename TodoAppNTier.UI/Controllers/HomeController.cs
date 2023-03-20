using Microsoft.AspNetCore.Mvc;
using TodoAppNTier.Busniess.Interfaces;
using TodoAppNTier.Dtos.WorkDtos;

namespace TodoAppNTier.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWorkServices _workServices;
        public HomeController(IWorkServices workServices)
        {
            _workServices = workServices;
        }

        public async Task<IActionResult> Index()
        {
            var workList = await _workServices.GetAll();
            return View(workList);
        }


        public async Task<IActionResult> Create()
        {
            WorkCreateDto dto = new WorkCreateDto();
            return View(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Create(WorkCreateDto createDto)
        {
            if (ModelState.IsValid)
            {
                await _workServices.Create(createDto);
                return RedirectToAction("Index");
            }
            return View(createDto);
        }




        public async Task<IActionResult> Update(int id)
        {
            var dto = await _workServices.GetById(id);
            return View(new WorkUpdateDto
            {
                Id= dto.Id,
                Definition = dto.Definition,
                IsCompleted = dto.IsCompleted,
            });
        }
        [HttpPost]
        public async Task<IActionResult> Update(WorkUpdateDto dto)
        {
            if (ModelState.IsValid)
            {
                await _workServices.Updated(dto);
                return RedirectToAction("Index");
            }
            return View(dto);
        }
    }
}
