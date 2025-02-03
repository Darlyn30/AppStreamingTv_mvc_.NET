using ITLATV_.Core.Application.Interfaces.Services;
using ITLATV_.Core.Application.ViewModels.Producers;
using ITLATV_.Core.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ITLATV_.Controllers
{
    public class ProducerController : Controller
    {
        private readonly IProducerService _producerService;

        public ProducerController(IProducerService producerService)
        {
            _producerService = producerService;
        }
        public async Task<IActionResult> Index()
        {
            var model = await _producerService.GetAllViewModel();
            ViewBag.Producers = model ?? new List<ProducerViewModel>();
            return View(model);
        }

        public IActionResult Create()
        {
            return View("SaveProducer", new SaveProducerViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(SaveProducerViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("SaveProducer", vm);
            }

            await _producerService.Add(vm);
            return RedirectToRoute(new { controller = "Producer", action = "Index" });
        }

        public async Task<IActionResult> Edit(int id)
        {
            return View("SaveProducer", await _producerService.GetByIdSaveViewModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SaveProducerViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("SaveProducer", vm);
            }

            await _producerService.Update(vm);
            return RedirectToRoute(new { controller = "Producer", action = "Index" });
        }

        public async Task<IActionResult> Delete(int id)
        {
            return View(await _producerService.GetByIdSaveViewModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {

            await _producerService.Delete(id);
            return RedirectToRoute(new { controller = "Producer", action = "Index" });
        }
    }
}
