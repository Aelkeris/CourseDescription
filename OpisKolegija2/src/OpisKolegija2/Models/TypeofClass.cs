using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpisKolegija2.Models
{
    public partial class TypeofClass
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CourseId { get; set; }
        public bool Lectures { get; set; }
        public bool Seminars { get; set; }
        public bool Lab { get; set; }
        public bool Distance { get; set; }
        public bool Mixed { get; set; }
        public bool Field { get; set; }
        public bool Homework { get; set; }
        public bool Multimedia { get; set; }
        public bool Exercises { get; set; }
        public bool Mentoring { get; set; }
        public bool OtherCheck { get; set; }
        public string OtherText { get; set; }
       
    }
}
