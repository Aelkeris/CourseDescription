using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpisKolegija2.Models
{
    public partial class GeneralInformations
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CourseId { get; set; }
        public string CurriculumName { get; set; }
        public string CourseStatus { get; set; }
        public string Semester { get; set; }
        public string Ects { get; set; }
        public string HoursLecture { get; set; }
        public string HoursLab { get; set; }
        public string HoursSeminar { get; set; }
        public string ShortName { get; set; }
        public string CourseCode { get; set; }
        public string CourseGoals { get; set; }
        public string Prerequisites { get; set; }
        public string LearningOutcomes { get; set; }
        public string Comments { get; set; }

        public Courses Courses { get; set; }
    }
}
