using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITLATV_.Core.Domain.Entities.Common;

namespace ITLATV_.Core.Domain.Entities
{
    public class Producer : BaseBasicEntity
    {
        public string ImgPath { get; set; }
        public ICollection<Serie> Series { get; set; } = new List<Serie>();
    }
}
