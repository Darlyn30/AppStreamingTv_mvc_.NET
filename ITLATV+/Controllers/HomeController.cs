using System.Diagnostics;
using ITLATV.Core.Application.Interfaces.Services;
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
        public HomeController(ISerieService serieService, IProducerService productoraService, IGenderService generoService)
        {
            _serieService = serieService;
            _producerService = productoraService;
            _genderService = generoService;
        }

        public async Task<IActionResult> Index(FilterSerieViewModel vm)
        {
            ViewBag.Productoras = await _producerService.GetAllViewModel();
            ViewBag.Generos = await _genderService.GetAllViewModel();
            return View(await _serieService.GetAllViewModel());

        }

        public async Task<IActionResult> Productora(FilterSerieViewModel vm)
        {
            ViewBag.Productoras = await _producerService.GetAllViewModel();
            ViewBag.Generos = await _genderService.GetAllViewModel();
            return View("Index", await _serieService.GetAllViewModelWithFilters(vm));

        }
        public async Task<IActionResult> Genero(FilterSerieViewModel vm)
        {
            ViewBag.Productoras = await _producerService.GetAllViewModel();
            ViewBag.Generos = await _genderService.GetAllViewModel();
            return View("Index", await _serieService.GetAllViewModelWithFiltersG(vm));

        }

        public async Task<IActionResult> Search(string nombreSerie)
        {
            ViewBag.Productoras = await _producerService.GetAllViewModel();
            ViewBag.Generos = await _genderService.GetAllViewModel();

            return View("Index", await _serieService.GetByNameAsync(nombreSerie));
        }
    }
}
