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
    public class GenderService
    {
        private readonly GenderRepository _genderRepository;
        public GenderService(ApplicationContext _context)
        {
            _genderRepository = new(_context);
        }

        public async Task<List<GenderViewModel>> GetGendersAsync()
        {
            var genders = await _genderRepository.GetGenders();
            return genders.Select(x => new GenderViewModel
            {
                Name = x.Name,
                Id = x.Id,
                Description = x.Description!,
            }).ToList();
        }

        public async Task<List<GenderViewModel>> GetGendersWithSeriesAsync()
        {
            var genders = await _genderRepository.GetGendersWithSeries();
            return genders.Select(g => new GenderViewModel
            {
                Id = g.Id,
                Name = g.Name,
                Description = g.Description!,
                Series = g.Series.Select(s => new SerieViewModel
                {
                    Id = s.Id,
                    Name = s.Name,
                    DateLaunch = s.DateLaunch,
                }).ToList()
            }).ToList();
        }

    }
}
