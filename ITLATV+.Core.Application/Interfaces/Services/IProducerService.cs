using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITLATV_.Core.Application.ViewModels.Producers;

namespace ITLATV_.Core.Application.Interfaces.Services
{
    public interface IProducerService : IGenericService<SaveProducerViewModel, ProducerViewModel>
    {
    }
}
