using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITLATV_.Core.Application.ViewModels.Series;

namespace ITLATV_.Core.Application.Interfaces.Services
{
    public interface ISerieService : IGenericService<SaveSerieViewModel, SerieViewModel>
    {
        Task<List<SerieViewModel>> GetByNameAsync(string serieName);
        Task<List<SerieViewModel>> GetAllViewModelWithFilters(FilterSerieViewModel filters);
        Task<List<SerieViewModel>> GetAllViewModelWithFiltersG(FilterSerieViewModel filters);
        Task<SerieViewModel> GetById(int id);
    }
}
