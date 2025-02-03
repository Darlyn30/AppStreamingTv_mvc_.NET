using ITLATV_.Core.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace ITLATV_.Controllers
{
    public class PlayContentController : Controller
    {
        private readonly ISerieService _serieService;

        public PlayContentController(ISerieService serieService)
        {
            _serieService = serieService;
        }
        public async Task<IActionResult> Index(int id)
        {
            var model = await _serieService.GetById(id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }
    }
}
