using System.Diagnostics;
using ITLATV_.Core.Application.Interfaces.Services;
using ITLATV_.Core.Application.ViewModels.Series;
using ITLATV_.Models;
using Microsoft.AspNetCore.Mvc;

namespace ITLATV_.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISerieService _serieService;
        private readonly IProducerService _producerService;
        private readonly IGenderService _genderService;
        public HomeController(ISerieService serieService, IProducerService producerService, IGenderService genderService)
        {
            _serieService = serieService;
            _producerService = producerService;
            _genderService = genderService;
        }

        public async Task<IActionResult> Index(FilterSerieViewModel vm)
        {
            ViewBag.Producer = await _producerService.GetAllViewModel();
            ViewBag.Gender = await _genderService.GetAllViewModel();
            return View(await _serieService.GetAllViewModel());

        }

        public async Task<IActionResult> Producer(FilterSerieViewModel vm)
        {
            ViewBag.Producer = await _producerService.GetAllViewModel();
            ViewBag.Gender = await _genderService.GetAllViewModel();
            return View("Index", await _serieService.GetAllViewModelWithFilters(vm));

        }
        public async Task<IActionResult> Gender(FilterSerieViewModel vm)
        {
            ViewBag.Producer = await _producerService.GetAllViewModel();
            ViewBag.Gender = await _genderService.GetAllViewModel();
            return View("Index", await _serieService.GetAllViewModelWithFiltersG(vm));

        }

        public async Task<IActionResult> Search(string serieName)
        {
            ViewBag.Producer = await _producerService.GetAllViewModel();
            ViewBag.Gender = await _genderService.GetAllViewModel();

            return View("Index", await _serieService.GetByNameAsync(serieName));
        }
    }
}
