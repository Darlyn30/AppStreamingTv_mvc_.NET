using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database.Context;
using Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository
{
    public class ProducerRepository
    {
        private readonly ApplicationContext _context;
        public ProducerRepository(ApplicationContext _context)
        {
            this._context = _context;
        }

        public async Task<List<Producer>> GetProducers()
        {
            var result = await _context.Producers.ToListAsync();
            return result;
        }
    }
}
