using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database.Entities;

namespace Application.ViewModels
{
    public class SerieViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } 
        public string? Description { get; set; }
        public string GenderName { get; set; }
        public string ProducerName {  get; set; }
        public string ImagePath {  get; set; }
        public DateOnly DateLaunch { get; set; }

    }
}
