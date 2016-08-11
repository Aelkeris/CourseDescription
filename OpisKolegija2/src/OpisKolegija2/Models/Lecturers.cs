using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpisKolegija2.Models
{
    public partial class Lecturers
    {
        [Key]
        public int LecturerId { get; set; }
        public string Lecturer { get; set; }
    }
}
