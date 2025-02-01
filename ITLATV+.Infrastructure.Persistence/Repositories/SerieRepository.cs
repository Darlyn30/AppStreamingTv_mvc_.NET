
using ITLATV.Infrastructure.Persistence.Repositories;
using ITLATV_.Core.Application.Interfaces.Repositories;
using ITLATV_.Core.Domain.Entities;
using ITLATV_.Infrastructure.Persistence.Contexts;

namespace ITLATV.Infrastucture.Persistence.Repositories
{
    public class SerieRepository : GenericRepository<Serie>, ISerieRepository
    {
        private readonly ApplicationContext _context;

        public SerieRepository(ApplicationContext _context) : base(_context)
        {
            this._context = _context;
        }
    }
}
