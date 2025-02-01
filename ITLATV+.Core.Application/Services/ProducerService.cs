using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITLATV.Core.Application.Interfaces.Services;
using ITLATV_.Core.Application.Interfaces.Repositories;
using ITLATV_.Core.Application.ViewModels.Producers;
using ITLATV_.Core.Domain.Entities;

namespace ITLATV_.Core.Application.Services
{
    public class ProducerService : IProducerService
    {
        private readonly IProducerRepository _producerRepo;
        public ProducerService(IProducerRepository producerRepo)
        {
            _producerRepo = producerRepo;
        }
        public async Task Add(SaveProducerViewModel vm)
        {
            Producer producer = new();
            producer.Name = vm.Name;

            await _producerRepo.AddAsync(producer);
        }

        public async Task Delete(int id)
        {
            var producer = await _producerRepo.GetByIdAsync(id);
            await _producerRepo.DeleteAsync(producer);
        }

        public async Task<List<ProducerViewModel>> GetAllViewModel()
        {
            var producerList = await _producerRepo.GetAllWithIncludeAsync(new List<string> { "Series" });

            return producerList.Select(producer => new ProducerViewModel
            {
                Name = producer.Name,
                Id = producer.Id,
                SeriesCount = producer.Series.Count()

            }).ToList();
        }

        public async Task<SaveProducerViewModel> GetByIdSaveViewModel(int id)
        {
            var producer = await _producerRepo.GetByIdAsync(id);

            SaveProducerViewModel vm = new();
            vm.Id = producer.Id;
            vm.Name = producer.Name;

            return vm;
        }

        public async Task Update(SaveProducerViewModel vm)
        {
            Producer producer = new();
            producer.Id = vm.Id;
            producer.Name = vm.Name;

            await _producerRepo.UpdateAsync(producer);
        }
    }
}
