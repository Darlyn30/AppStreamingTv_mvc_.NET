using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITLATV_.Core.Domain.Entities.Common;

namespace ITLATV_.Core.Domain.Entities
{
    public class Serie : BaseBasicEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string imgPath { get; set; }
        public string LinkVideo { get; set; }
        public DateOnly ReleaseDate { get; set; }
        public int GenderId { get; set; }
        public Gender? Gender { get; set; }

        // Una serie tiene una productora, una productora puede tener varias series.
        public int ProducerId { get; set; }
        public Producer? Producer { get; set; }
    }
}