using ITLATV_.Core.Application.Interfaces.Services;
using ITLATV_.Infrastructure.Persistence.Contexts;
using Microsoft.AspNetCore.Mvc;

namespace ITLATV_.Controllers
{
    public class PlayContentController : Controller
    {
        private readonly ISerieService _serieService;
        private readonly IGenderService _genderService;
        private readonly IProducerService _producerService;
        public PlayContentController(ISerieService serieService, IProducerService producerService, IGenderService genderService)
        {
            _serieService = serieService;
            _producerService = producerService;
            _genderService = genderService;
            
        }
        public async Task<IActionResult> Index(int id)
        {
            ViewBag.Producers = await _producerService.GetAllViewModel();
            ViewBag.Genders = await _genderService.GetAllViewModel();
            var model = await _serieService.GetById(id);
            if (model == null!)
            {
                return NotFound();
            }
            return View("Index", model);
        }
    }
}
