using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITLATV_.Core.Application.Interfaces.Repositories;
using ITLATV_.Core.Application.Interfaces.Services;
using ITLATV_.Core.Application.ViewModels.Series;
using ITLATV_.Core.Domain.Entities;

namespace ITLATV_.Core.Application.Services
{
    public class SerieService : ISerieService
    {
        private readonly ISerieRepository _serieRepository;
        public SerieService(ISerieRepository serieRepository)
        {
            _serieRepository = serieRepository;
        }

        public async Task Update(SaveSerieViewModel vm)
        {
            Serie serie = new();
            serie.Id = vm.Id;
            serie.Name = vm.Name;
            serie.imgPath = vm.ImgPath;
            serie.LinkVideo = vm.LinkVideo;
            serie.GenderId = vm.GenderId;
            serie.ProducerId = vm.ProducerId;

            await _serieRepository.UpdateAsync(serie);

        }

        public async Task Add(SaveSerieViewModel vm)
        {
            Serie serie = new();
            serie.Name = vm.Name;
            serie.imgPath = vm.ImgPath;
            serie.LinkVideo = vm.LinkVideo;
            serie.GenderId = vm.GenderId;
            serie.ProducerId = vm.ProducerId;

            await _serieRepository.AddAsync(serie);
        }

        public async Task Delete(int id)
        {
            var serie = await _serieRepository.GetByIdAsync(id);
            await _serieRepository.DeleteAsync(serie);
        }

        public async Task<SerieViewModel> GetById(int id)
        {
            var serie = await _serieRepository.GetByIdAsync(id);
            return new SerieViewModel
            {
                Id = serie.Id,
                Name = serie.Name,
                ImgPath = serie.imgPath,
                Description = serie.Description,
                LinkVideo = serie.LinkVideo,
                GenderId = serie.GenderId,
                ProducerId = serie.ProducerId,
                GenderName = serie.Gender?.Name,
                ProducerName = serie.Producer?.Name,
            };
        }
        public async Task<SaveSerieViewModel> GetByIdSaveViewModel(int id)
        {
            var serie = await _serieRepository.GetByIdAsync(id);

            SaveSerieViewModel vm = new();
            vm.Id = serie.Id;
            vm.Name = serie.Name;
            vm.ImgPath = serie.imgPath;
            vm.LinkVideo = serie.LinkVideo;
            vm.GenderId = serie.GenderId;
            vm.ProducerId = serie.ProducerId;

            return vm;
        }

        public async Task<List<SerieViewModel>> GetAllViewModel()
        {
            var serieList = await _serieRepository.GetAllWithIncludeAsync(new List<string> { "Gender", "Producer" });

            return serieList.Select(serie => new SerieViewModel
            {
                Id = serie.Id,
                Name = serie.Name,
                ImgPath = serie.imgPath,
                GenderId = serie.Gender != null ? serie.Gender.Id : 0,
                GenderName = serie.Gender != null ? serie.Gender.Name : null,
                ProducerId = serie.Producer != null ? serie.Producer.Id : 0,
                ProducerName = serie.Producer != null ? serie.Producer.Name : null

            }).ToList();
        }


        public async Task<List<SerieViewModel>> GetAllViewModelWithFilters(FilterSerieViewModel filters)
        {
            var serieList = await _serieRepository.GetAllWithIncludeAsync(new List<string> { "Producer", "Gender" });

            var listViewModels = serieList.Select(serie => new SerieViewModel
            {
                Id = serie.Id,
                Name = serie.Name,
                ImgPath = serie.imgPath,
                GenderId = serie.Gender != null ? serie.Gender.Id : 0,
                GenderName = serie.Gender != null ? serie.Gender.Name : null,
                ProducerName = serie.Producer.Name,
                ProducerId = serie.Producer.Id

            }).ToList();

            if (filters.ProducerId != null)
            {
                listViewModels = listViewModels.Where(producer => producer.ProducerId == filters.ProducerId.Value).ToList();
            }

            return listViewModels;
        }

        public async Task<List<SerieViewModel>> GetAllViewModelWithFiltersG(FilterSerieViewModel filters)
        {
            var serieList = await _serieRepository.GetAllWithIncludeAsync(new List<string> { "Producer", "Gender" });

            var listViewModels = serieList.Select(serie => new SerieViewModel
            {
                Id = serie.Id,
                Name = serie.Name,
                ImgPath = serie.imgPath,
                GenderId = serie.Gender != null ? serie.Gender.Id : 0,
                GenderName = serie.Gender != null ? serie.Gender.Name : null,
                ProducerName = serie.Producer.Name,
                ProducerId = serie.Producer.Id

            }).ToList();

            if (filters.GenderId != null)
            {
                listViewModels = listViewModels.Where(gender => gender.GenderId == filters.GenderId.Value).ToList();
            }

            return listViewModels;
        }

        public async Task<List<SerieViewModel>> GetByNameAsync(string serieName)
        {
            var serieList = await _serieRepository.GetAllWithIncludeAsync(new List<string> { "Producer", "Gender" });

            var listViewModels = serieList.Select(serie => new SerieViewModel
            {
                Id = serie.Id,
                Name = serie.Name,
                ImgPath = serie.imgPath,
                GenderId = serie.Gender != null ? serie.Gender.Id : 0,
                GenderName = serie.Gender != null ? serie.Gender.Name : null,
                ProducerName = serie.Producer.Name,
                ProducerId = serie.Producer.Id

            }).ToList();

            if (serieName != null)
            {
                listViewModels = listViewModels.Where(serie => serie.Name.ToLower().Contains(serieName.ToLower())).ToList();
            }

            return listViewModels;
        }
    }
}
