using ITLATV_.Core.Application.Interfaces.Repositories;
using ITLATV_.Core.Application.Interfaces.Services;
using ITLATV_.Core.Application.ViewModels.Genders;
using Microsoft.AspNetCore.Mvc;

namespace ITLATV_.Controllers
{
    public class GenderController : Controller
    {
        private readonly IGenderService _genderService;

        public GenderController(IGenderService genderService)
        {
            _genderService = genderService;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _genderService.GetAllViewModel();
            return View(model);
        }

        public IActionResult Create()
        {
            return View("SaveGender", new SaveGenderViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(SaveGenderViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("SaveGender", vm);
            }

            await _genderService.Add(vm);
            return RedirectToRoute(new { controller = "Gender", action = "Index" });
        }

        public async Task<IActionResult> Edit(int id)
        {
            return View("SaveGender", await _genderService.GetByIdSaveViewModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SaveGenderViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("SaveGender", vm);
            }

            await _genderService.Update(vm);
            return RedirectToRoute(new { controller = "Gender", action = "Index" });
        }

        public async Task<IActionResult> Delete(int id)
        {
            return View(await _genderService.GetByIdSaveViewModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {

            await _genderService.Delete(id);
            return RedirectToRoute(new { controller = "Gender", action = "Index" });
        }
    }
}
