using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class GenericViewModel
    {
        public List<GenderViewModel> Genders { get; set; } // Para el select
        public List<SerieViewModel> Series { get; set; } // Para mostrar las series
    }
}
