using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ITLATV.Infrastructure.Persistence.Repositories;
using ITLATV.Infrastucture.Persistence.Repositories;
using ITLATV_.Core.Application.Interfaces.Repositories;
using ITLATV_.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ITLATV_.Infrastructure.Persistence
{
    public static class ServiceRegister
    {
        public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            #region contexts

            services.AddDbContext<ApplicationContext>(option =>
            option.UseSqlServer(configuration.GetConnectionString("AppConnection"),
            m => m.MigrationsAssembly(typeof(ApplicationContext).Assembly.FullName)));

            #endregion

            #region Repositories
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<IGenderRepository, GenderRepository>();
            services.AddTransient<ISerieRepository, SerieRepository>();
            services.AddTransient<IProducerRepository, ProducerRepository>();
            #endregion
        }
    }
}
