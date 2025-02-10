using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using ITLATV_.Core.Application.Interfaces.Repositories;
using ITLATV_.Infrastructure.Persistence.Contexts;

namespace ITLATV.Infrastructure.Persistence.Repositories
{
    //Generics
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationContext _context;
       
        public GenericRepository(ApplicationContext _context)
        {
            this._context = _context;
        }

        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
             _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();//Deferred execution
        }

        public async Task<List<T>> GetAllWithIncludeAsync(List<string> props)
        {
            var query = _context.Set<T>().AsQueryable();

            foreach(string property in props)
            {
                query = query.Include(property);
            }

            return await query.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

    }
}
