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
        public SerieService(ApplicationContext _context)
        {
            _repository = new(_context);
        }

        public async Task<List<SerieViewModel>> GetAllAsync()
        {
            
            var list = await _repository.GetAll();
            return list.Select(x => new SerieViewModel
            {
                Name = x.Name,
                Description = x.Description,
                ImagePath = x.ImagePath,
                Gender = x.Genderr,
                Producer = x.Producerr,
                DateLaunch = x.DateLaunch,

            }).ToList();
        }

        
    }
}
