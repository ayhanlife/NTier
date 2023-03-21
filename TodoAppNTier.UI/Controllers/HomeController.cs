using Azure;
using Microsoft.AspNetCore.Mvc;
using TodoAppNTier.Busniess.Interfaces;
using TodoAppNTier.Common.ResponseObjects;
using TodoAppNTier.Dtos.WorkDtos;
using TodoAppNTier.UI.Extensions;

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
            var response = await _workServices.GetAll();
            return View(response.Data);
        }


        public async Task<IActionResult> Create()
        {
            return View(new WorkCreateDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create(WorkCreateDto createDto)
        {
            var response = await _workServices.Create(createDto);
            return this.ResponseRedirectoAction(response, "Index");
            //if (response.ResponseType == ResponseType.ValidationError)
            //{
            //    foreach (var error in response.ValidationErrors)
            //    {
            //        ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
            //    }
            //    return View(createDto);
            //}
            //else
            //{
            //    return RedirectToAction("Index");
            //}
        }

        public async Task<IActionResult> Update(int id)
        {
            var response = await _workServices.GetById<WorkUpdateDto>(id);
            return this.ResponseView(response);

            //if (response.ResponseType == ResponseType.NotFound)
            //{
            //    return NotFound();
            //}
            //return View(response.Data);
        }

        [HttpPost]
        public async Task<IActionResult> Update(WorkUpdateDto dto)
        {
            var response = await _workServices.Updated(dto);
            return this.ResponseRedirectoAction(response, "Index");
        }


        public async Task<IActionResult> Remove(int id)
        {
            var response = await _workServices.Remove(id);
            return this.ResponseRedirectoAction(response, "Index");

            //if (response.ResponseType == ResponseType.NotFound)
            //{
            //    return NotFound();
            //}
            //return RedirectToAction("Index");
        }

        public async Task<IActionResult> NotFound(int code)
        {

            return View();
        }
    }
}
