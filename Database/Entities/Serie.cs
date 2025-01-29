using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database.Common;

namespace Database.Entities
{
    public class Serie : BaseBasicEntity
    {
        public string? Description { get; set; }
        public string ImagePath { get; set; }
        public DateOnly DateLaunch { get; set; }

        //this work like FK for the table series
        public string? GenderName { get; set; }
        public string? ProducerName { get; set; }

        //Navigation Properties
        public Gender? Gender { get; set; }
        public Producer? Producer { get; set; }
    }
}
