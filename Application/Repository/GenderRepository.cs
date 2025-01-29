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
    public class GenderRepository
    {
        private readonly ApplicationContext _context;

        public GenderRepository(ApplicationContext _context)
        {
            this._context = _context;
        }

        public async Task<List<Gender>> GetGenders()
        {
            return await _context.Genders.ToListAsync();
        }

        public async Task<List<Gender>> GetGendersWithSeries()
        {
            return await _context.Genders
                .Include(g => g.Series)  // Asegúrate de que la relación está bien configurada en tu modelo
                .ToListAsync();
        }
    }
}
