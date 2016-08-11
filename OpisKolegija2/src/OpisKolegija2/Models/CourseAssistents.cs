using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpisKolegija2.Models
{
    public partial class CourseAssistents
    {
        [Key]
        [ForeignKey(nameof(Courses))]
        public int CourseId { get; set; }
        public Courses Courses { get; set; }
        
        [Key]
        [ForeignKey(nameof(Assistents))]
        public int AssistentId { get; set; }
        public Assistents Assistents { get; set; }

     
    }
}
