using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpisKolegija2.Models
{
    public partial class Courses
    {
        [Key]
        public int CourseId { get; set; }
        public string CourseTitle { get; set; }

        public GeneralInformations GeneralInformations { get; set; }
    }
}
