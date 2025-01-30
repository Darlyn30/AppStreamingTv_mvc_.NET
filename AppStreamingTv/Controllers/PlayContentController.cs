using Application.Services;
using Database.Context;
using Database.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AppStreamingTv.Controllers
{
    public class PlayContentController : Controller
    {
        private readonly ContentService _service;

        public PlayContentController(ApplicationContext _context)
        {
            _service = new(_context);
        }
    }
}
