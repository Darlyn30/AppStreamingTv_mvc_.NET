using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITLATV_.Core.Application.ViewModels.Producers
{
    public class SaveProducerViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "You must enter the name of the producer.")]
        public string Name { get; set; }
        public string ImgPath { get; set; }
    }
}
