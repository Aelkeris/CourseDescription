using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpisKolegija2.Models
{
    public partial class CLA
    {
        public string CourseTitle { get; set; }
        public int[] LecturerId { get; set; }
        public int[] AssistentId { get; set; }
    }
}
