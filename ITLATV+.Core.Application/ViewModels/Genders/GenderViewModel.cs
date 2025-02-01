using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITLATV_.Core.Domain.Entities;

namespace ITLATV_.Core.Application.ViewModels.Genders
{
    public class GenderViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SeriesCount { get; set; }
    }
}
