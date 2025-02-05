using ITLATV_.Core.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace ITLATV_.Controllers;

public class SerieController : Controller
{
    private readonly ISerieService _serieService;
    private readonly IProducerService _producerService;
    private readonly IGenderService _genderService;

    public SerieController(ISerieService serieService, IProducerService producerService, IGenderService genderService)
    {
        _serieService = serieService;
        _producerService = producerService;
        _genderService = genderService;
    }

    public async Task<IActionResult> Create()
    {
        SaveSerieViewModel model = new();
        model.Producers = await _producerService.GetAllViewModel();
        model.Genders = await _genderService.GetAllViewModel();
        return View("Create", model);
    }
    [HttpPost]
    public async Task<IActionResult> Create(SaveSerieViewModel model)
    {
        if (!ModelState.IsValid)
        {
            model.Producers = await _producerService.GetAllViewModel();
            model.Genders = await _genderService.GetAllViewModel();
            return View("Create", model);
        }

        await _serieService.Add(model);
        return RedirectToRoute(new { controller = "Home", action = "Index" });
    }
    public async Task<IActionResult> Edit(int id)
    {
        SaveSerieViewModel model = await _serieService.GetByIdSaveViewModel(id);
        model.Producers = await _producerService.GetAllViewModel();
        model.Genders = await _genderService.GetAllViewModel();
        return View("Create", model);
    }
    [HttpPost]
    public async Task<IActionResult> Edit(SaveSerieViewModel model)
    {
        if (!ModelState.IsValid)
        {
            model.Producers = await _producerService.GetAllViewModel();
            model.Genders = await _genderService.GetAllViewModel();

            return View("Create", model);
        }

        await _serieService.Update(model);
        return RedirectToRoute(new { controller = "Home", action = "Index" });
    }
    
    public async Task<IActionResult> Delete(int id)
    {
        var model = await _serieService.GetByIdSaveViewModel(id);
        return View(model);
    }
    [HttpPost]
    public async Task<IActionResult> DeleteSerie(int id)
    {

        await _serieService.Delete(id);
        return RedirectToRoute(new { controller = "Home", action = "Index" });
    }
}