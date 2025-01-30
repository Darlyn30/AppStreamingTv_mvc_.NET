using Application.Services;
using Application.ViewModels;
using Database.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppStreamingTv.Controllers
{
    public class GenderController : Controller
    {
        private readonly SerieService _service;
        public GenderController(ApplicationContext _context)
        {
            _service = new(_context);
        }
        public async Task<IActionResult> Index()
        {
            var model = new GenericViewModel
            {
                Genders = await _service.GetGenders(),
                Series = await _service.GetAllAsync()
            };
            return View(model);
        }
    }
}
