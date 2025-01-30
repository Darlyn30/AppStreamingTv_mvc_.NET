using System.Diagnostics;
using Application.Services;
using Application.ViewModels;
using AppStreamingTv.Models;
using Database.Context;
using Microsoft.AspNetCore.Mvc;

namespace AppStreamingTv.Controllers
{
    public class HomeController : Controller
    {
        private readonly SerieService _service;
        private readonly ContentService _contService;

        public HomeController(ApplicationContext _context)
        {
            _service = new(_context);
        }

        public async Task<IActionResult> Index()
        {
            return View(await _service.GetAllAsync());
        }

        public async Task<IActionResult> Play(int id)
        {


            return View(await _contService.PlayContent(id));
        }


    }
}
