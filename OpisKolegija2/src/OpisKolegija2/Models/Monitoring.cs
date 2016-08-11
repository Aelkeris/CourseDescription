using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpisKolegija2.Models
{
    public partial class Monitoring
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CourseId { get; set; }
        public string ClassAttendance { get; set; }
        public string ExperimentalWork { get; set; }
        public string Essay { get; set; }
        public string ShortTest { get; set; }
        public string ClassActivity { get; set; }
        public string WrittenExam { get; set; }
        public string Research { get; set; }
        public string Report { get; set; }
        public string Seminar { get; set; }
        public string OralExam { get; set; }
        public string Project { get; set; }
        public string PracticalWork { get; set; }
        public string ContinuousAssessment { get; set; }
    }
}
