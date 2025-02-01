using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITLATV_.Core.Application.ViewModels.Series
{
    public class SerieViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImgPath { get; set; }
        public string LinkVideo { get; set; }
        public DateOnly ReleaseDate { get; set; }

        //this work like FK for the table series
        public int GenderId { get; set; }
        public string? GenderName { get; set; }
        public int ProducerId {  get; set; }
        public string? ProducerName { get; set; }
    }
}
