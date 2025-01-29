using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Repository;
using Application.ViewModels;
using Database.Context;

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
                Name = x.Name,
                Description = x.Description,
                ImagePath = x.ImagePath,
                DateLaunch = x.DateLaunch,

            }).ToList();
        }


        public async Task<List<SerieViewModel>> GetSeriesByGenderAsync(string genderName)
        {
            var series = await _repository.GetSeriesByGenderAsync(genderName);
            return series.Select(s => new SerieViewModel
            {
                Name = s.Name,
                Description = s.Description,
                ImagePath = s.ImagePath,
                Gender = s.Gender!.Name,  // Evita valores nulos
                Producer = s.Producer!.Name,
                DateLaunch = s.DateLaunch
            }).ToList();
        }


    }
}
