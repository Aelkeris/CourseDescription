using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpisKolegija2.Models
{
    public partial class CoursesViewModel
    {
        public int id {get; set;}
        public string nazivPredmeta { get; set; }

        public List<string> profesori = new List<string>();
    }
}
