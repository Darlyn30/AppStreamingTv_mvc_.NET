using ITLATV.Infrastructure.Persistence.Repositories;
using ITLATV_.Core.Application.Interfaces.Repositories;
using ITLATV_.Core.Domain.Entities;
using ITLATV_.Infrastructure.Persistence.Contexts;

namespace ITLATV.Infrastucture.Persistence.Repositories
{
    public class ProducerRepository : GenericRepository<Producer>, IProducerRepository
    {
        private readonly ApplicationContext _dbContext;
        public ProducerRepository(ApplicationContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
