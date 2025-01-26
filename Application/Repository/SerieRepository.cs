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
    public class SerieRepository
    {
        private readonly ApplicationContext _context;
        public SerieRepository(ApplicationContext _context)
        {
            this._context = _context;
        }

        public async Task<List<Serie>> GetAll()
        {
            return await _context.Series.ToListAsync();
        }
    }
}
