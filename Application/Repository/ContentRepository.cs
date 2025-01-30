using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.ViewModels;
using Database.Context;
using Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository
{
    public class ContentRepository
    {
        private readonly ApplicationContext _context;
        public ContentRepository(ApplicationContext _context)
        {
            this._context = _context;
        }

        //method to "play" content
        public async Task<Serie> GetSerieByIdAsync(int id)
        {
            return await _context.Series
                .FirstOrDefaultAsync(s => s.Id == id);
        }
    }
}
