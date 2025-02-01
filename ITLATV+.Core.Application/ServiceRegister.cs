using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITLATV.Core.Application.Interfaces.Services;
using ITLATV_.Core.Application.Interfaces;
using ITLATV_.Core.Application.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ITLATV_.Core.Application
{
    public static class ServiceRegister
    {
        public static void AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            #region Services
            services.AddTransient<IGenderService, GenderService>();
            services.AddTransient<ISerieService, SerieService>();
            services.AddTransient<IProducerService, ProducerService>();
            #endregion
        }
    }
}
