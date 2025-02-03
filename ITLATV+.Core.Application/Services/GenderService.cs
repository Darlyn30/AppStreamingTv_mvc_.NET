using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITLATV_.Core.Application.Interfaces.Repositories;
using ITLATV_.Core.Application.Interfaces.Services;
using ITLATV_.Core.Application.ViewModels.Genders;
using ITLATV_.Core.Domain.Entities;

namespace ITLATV_.Core.Application.Services
{
    public class GenderService : IGenderService
    {
        private readonly IGenderRepository _generoRepository;

        public GenderService(IGenderRepository _generoRepository)
        {
            this._generoRepository = _generoRepository;
        }

        public async Task Update(SaveGenderViewModel vm)
        {
            Gender gender = new();
            gender.Id = vm.Id;
            gender.Name = vm.Name;

            await _generoRepository.UpdateAsync(gender);
        }

        public async Task Add(SaveGenderViewModel vm)
        {
            Gender gender = new();
            gender.Name = vm.Name;

            await _generoRepository.AddAsync(gender);
        }

        public async Task Delete(int id)
        {
            var gender = await _generoRepository.GetByIdAsync(id);
            await _generoRepository.DeleteAsync(gender);
        }

        public async Task<SaveGenderViewModel> GetByIdSaveViewModel(int id)
        {
            var gender = await _generoRepository.GetByIdAsync(id);

            SaveGenderViewModel vm = new();
            vm.Id = gender.Id;
            vm.Name = gender.Name;

            return vm;
        }

        public async Task<List<GenderViewModel>> GetAllViewModel()
        {
            var generoList = await _generoRepository.GetAllWithIncludeAsync(new List<string> { "Series" });

            return generoList.Select(gender => new GenderViewModel
            {
                Name = gender.Name,
                Id = gender.Id,
                SeriesCount = gender.Series.Count()
            }).ToList();
        }

    }
}
