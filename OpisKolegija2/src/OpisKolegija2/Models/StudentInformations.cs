using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpisKolegija2.Models
{
    public partial class StudentInformations
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CourseId { get; set; }
        public string StudentTasks { get; set; }
        public string Workload { get; set; }
        public string GradingEvaluating { get; set; }
        public string Required1 { get; set; }
        public string Required2 { get; set; }
        public string Required3 { get; set; }
        public string Required4 { get; set; }
        public string Required5 { get; set; }
        public string Recommended1 { get; set; }
        public string Recommended2 { get; set; }
        public string Recommended3 { get; set; }
        public string Recommended4 { get; set; }
        public string Recommended5 { get; set; }
    }
}
