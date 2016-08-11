using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using OpisKolegija2.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace OpisKolegija2.Models
{
    public partial class CourseLecturers
    {
        [Key]
        [ForeignKey(nameof(Courses))]
        public int CourseId { get; set; }
        public Courses Courses { get; set; }

        [Key]
        [ForeignKey(nameof(Lecturers))]
        public int LecturerId { get; set; }
        public Lecturers Lecturers { get; set; }
    }
 

}
