using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database.Common;

namespace Database.Entities
{
    public class Gender : BaseBasicEntity
    {
        public string? Description { get; set; }
        public ICollection<Serie> Series { get; set; }
    }
}
