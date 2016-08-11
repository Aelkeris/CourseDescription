using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpisKolegija2.Models
{
    public partial class AllData
    {
        public Courses Courses { get; set; }
        public List<Lecturers> LecturersList { get; set; }
        
        public List<Assistents> AssistentsList { get; set; }
        
        public GeneralInformations GeneralInformations { get; set; }
        public List<Details> DetailsList { get; set; }
        public TypeofClass TypeofClass { get; set; }
        public Monitoring Monitoring { get; set; }
        public StudentInformations StudentInformations { get; set; }
        public AdditionalInformations AdditionalInformations { get; set; }

    }
}
