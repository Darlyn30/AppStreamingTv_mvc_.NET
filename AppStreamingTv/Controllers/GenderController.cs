using Application.Services;
using Application.ViewModels;
using Database.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppStreamingTv.Controllers
{
    public class GenderController : Controller
    {
        private readonly GenderService _service;
        public GenderController(ApplicationContext _context)
        {
            _service = new(_context);
        }
        public async Task<IActionResult> Index()
        {
            var model = await _service.GetGendersWithSeriesAsync();
            return View(model);
        }

        public async Task<IActionResult> Index(int? genreId)
        {
            var model = new GenderViewModel
            {
                // Cargar todos los géneros
                Series = genreId == null
                    ? _service.GetGendersAsync()// Si no hay género seleccionado, mostrar todas las series
                    : _context.Series
                        .Where(s => s.GenderId == genreId) // Filtrar las series por género
                        .Select(s => new SerieViewModel
                        {
                            Id = s.Id,
                            Name = s.Name,
                            Description = s.Description,
                            ImagePath = s.ImagePath
                        }).ToList()
            };

            // Cargar la lista de géneros para el dropdown
            ViewBag.Genres = _context.Genres.ToList();

            return View(model);
        }
}
