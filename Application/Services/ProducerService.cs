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
    public class ProducerService
    {
        private readonly ProducerRepository _producerRepo;

        public ProducerService(ApplicationContext _context)
        {
            _producerRepo = new(_context);    
        }

        public async Task<List<ProducerViewModel>> GetProducers()
        {
            var list = await _producerRepo.GetProducers();
            return list.Select(x => new ProducerViewModel
            {

            })
        }
    }
}
