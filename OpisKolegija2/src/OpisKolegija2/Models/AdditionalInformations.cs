using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpisKolegija2.Models
{
    public partial class AdditionalInformations
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CourseId { get; set; }
        public string Attendance { get; set; }
        public string ContactingTeacher { get; set; }
        public string ClassInformation { get; set; }
        public string WrittenWork { get; set; }
        public string Other { get; set; }
    }
}
