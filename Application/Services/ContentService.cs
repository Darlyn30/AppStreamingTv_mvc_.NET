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
    public class ContentService
    {
        private readonly ContentRepository _contentRepository;
        public ContentService(ApplicationContext _context)
        {
            _contentRepository = new(_context);
        }

        public async Task<SerieViewModel> PlayContent(int id)
        {
            var serie = await _contentRepository.GetSerieByIdAsync(id);
            if (serie == null)
            {
                return null;
            }

            return new SerieViewModel
            {
                Id = serie.Id,
                Name = serie.Name,
                Description = serie.Description,
                GenderName = serie.GenderName!,
                ProducerName = serie.ProducerName!,
                ImagePath = serie.ImagePath,
                DateLaunch = serie.DateLaunch
            };
        }

    }
}
