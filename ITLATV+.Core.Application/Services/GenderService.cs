using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITLATV.Core.Application.Interfaces.Services;
using ITLATV_.Core.Application.Interfaces.Repositories;
using ITLATV_.Core.Application.ViewModels.Genders;
using ITLATV_.Core.Domain.Entities;

namespace ITLATV_.Core.Application.Services
{
    internal class GenderService : IGenderService
    {
        private readonly IGenderRepository _generoRepository;

        public GenderService(IGenderRepository categoryRepository)
        {
            _generoRepository = categoryRepository;
        }

        public async Task Update(SaveGenderViewModel vm)
        {
            Gender genero = new();
            genero.Id = vm.Id;
            genero.Name = vm.Name;

            await _generoRepository.UpdateAsync(genero);
        }

        public async Task Add(SaveGenderViewModel vm)
        {
            Gender genero = new();
            genero.Name = vm.Name;

            await _generoRepository.AddAsync(genero);
        }

        public async Task Delete(int id)
        {
            var genero = await _generoRepository.GetByIdAsync(id);
            await _generoRepository.DeleteAsync(genero);
        }

        public async Task<SaveGenderViewModel> GetByIdSaveViewModel(int id)
        {
            var genero = await _generoRepository.GetByIdAsync(id);

            SaveGenderViewModel vm = new();
            vm.Id = genero.Id;
            vm.Name = genero.Name;

            return vm;
        }

        public async Task<List<GenderViewModel>> GetAllViewModel()
        {
            var generoList = await _generoRepository.GetAllWithIncludeAsync(new List<string> { "Series" });

            return generoList.Select(genero => new GenderViewModel
            {
                Name = genero.Name,
                Id = genero.Id,
                SeriesCount = genero.Series.Count()
            }).ToList();
        }

    }
}
