using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Repository;
using Application.ViewModels;
using Database.Context;
using Database.Entities;

namespace Application.Services
{
    public class SerieService
    {
        private readonly SerieRepository _repository;
        private readonly ApplicationContext _context;
        public SerieService(ApplicationContext _context)
        {
            _repository = new(_context);
            this._context = _context;
        }

        public async Task<List<SerieViewModel>> GetAllAsync()
        {
            
            var list = await _repository.GetAll();
            return list.Select(x => new SerieViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                ImagePath = x.ImagePath,
                DateLaunch = x.DateLaunch,

            }).ToList();
        }

        public async Task<List<GenderViewModel>> GetGenders()
        {
            var list = await _repository.GetAll();
            return list.Select(x => new GenderViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
            }).ToList();
        }
    }
}
