using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace OpisKolegija2.Models
{
    public partial class CourseDescriptionTableContext : DbContext
    {
        public CourseDescriptionTableContext(DbContextOptions<CourseDescriptionTableContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdditionalInformations>(entity =>
            {
                entity.HasKey(e => e.CourseId)
                    .HasName("PK__addition__2AA84FD10BDB0A29");

                entity.ToTable("additionalInformations");

                entity.Property(e => e.CourseId)
                    .HasColumnName("courseId")
                    .ValueGeneratedNever();

                entity.Property(e => e.Attendance)
                    .HasColumnName("attendance")
                    .HasColumnType("varchar(max)");

                entity.Property(e => e.ClassInformation)
                    .HasColumnName("classInformation")
                    .HasColumnType("varchar(max)");
                
                entity.Property(e => e.ContactingTeacher)
                    .HasColumnName("contactingTeacher")
                    .HasColumnType("varchar(max)");

                entity.Property(e => e.Other)
                    .HasColumnName("other")
                    .HasColumnType("varchar(max)");

                entity.Property(e => e.WrittenWork)
                    .HasColumnName("writtenWork")
                    .HasColumnType("varchar(max)");
            });

            modelBuilder.Entity<Assistents>(entity =>
            {
                entity.HasKey(e => e.AssistentId)
                    .HasName("PK_assistents");

                entity.ToTable("assistents");

                entity.Property(e => e.AssistentId).HasColumnName("assistentID");

                entity.Property(e => e.Assistent)
                    .IsRequired()
                    .HasColumnName("assistent");
            });

            modelBuilder.Entity<CourseAssistents>(entity =>
            {
                entity.HasKey(e => new { e.AssistentId, e.CourseId })
                    .HasName("PK_courseAssistents");

                entity.ToTable("courseAssistents");

                entity.Property(e => e.AssistentId).HasColumnName("assistentID");

                entity.Property(e => e.CourseId).HasColumnName("courseID");
            });

            modelBuilder.Entity<CourseLecturers>(entity =>
           {
                entity.HasKey(e => new { e.CourseId, e.LecturerId })
                    .HasName("PK_courseLecturers");

               entity.ToTable("courseLecturers");


               entity.Property(e => e.LecturerId).HasColumnName("lecturerID");

                entity.Property(e => e.CourseId).HasColumnName("courseID");
            });
           

            modelBuilder.Entity<Courses>(entity =>
            {
                entity.HasKey(e => e.CourseId)
                    .HasName("PK__Courses__2AA84FD13D168396");

                entity.Property(e => e.CourseId).HasColumnName("courseId");

                entity.Property(e => e.CourseTitle)
                    .IsRequired()
                    .HasColumnName("courseTitle")
                    .HasColumnType("varchar(50)");

                /*modelBuilder.Entity<Blog>()
                .HasOne(p => p.BlogImage)
                .WithOne(i => i.Blog)
                .HasForeignKey<BlogImage>(b => b.BlogForeignKey);*/
                //ako treba, ibrisat ću jedan na jedan vezu, maknuti increment i identity u bazi
                //i raditi sa onim jedinstvenim ključem kojeg si pošaljem 
                entity.HasOne(p => p.GeneralInformations)
                .WithOne(i => i.Courses)
                .HasForeignKey<GeneralInformations>(b => b.CourseId);
            });

            modelBuilder.Entity<Details>(entity =>
            {
                entity.ToTable("details");

                entity.Property(e => e.CourseId).HasColumnName("courseId");

                entity.Property(e => e.Description1)
                    .HasColumnName("description1")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Description2)
                    .HasColumnName("description2")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Description3)
                    .HasColumnName("description3")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Hours)
                    .HasColumnName("hours")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.WeekNo).HasColumnName("weekNo");
            });

            modelBuilder.Entity<GeneralInformations>(entity =>
            {
                entity.HasKey(e => e.CourseId)
                    .HasName("PK__generalI__2AA84FD161858BCE");

                entity.ToTable("generalInformations");

                entity.Property(e => e.CourseId)
                    .HasColumnName("courseId")
                    .ValueGeneratedNever();              

                entity.Property(e => e.Comments)
                    .HasColumnName("comments")
                    .HasColumnType("varchar(max)");

                entity.Property(e => e.CourseCode)
                    .HasColumnName("courseCode")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.CourseStatus)
                    .HasColumnName("courseStatus")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.CurriculumName)
                    .HasColumnName("curriculumName")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.CourseGoals)
                    .HasColumnName("CourseGoals")
                    .HasColumnType("varchar(max)");

                entity.Property(e => e.Ects)
                    .HasColumnName("ECTS")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.HoursLab)
                    .HasColumnName("hoursLab")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.HoursLecture)
                    .HasColumnName("hoursLecture")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.HoursSeminar)
                    .HasColumnName("hoursSeminar")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.LearningOutcomes)
                    .HasColumnName("learningOutcomes")
                    .HasColumnType("varchar(max)");             

                entity.Property(e => e.Prerequisites)
                    .HasColumnName("prerequisites")
                    .HasColumnType("varchar(max)");

                entity.Property(e => e.Semester)
                    .HasColumnName("semester")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.ShortName)
                    .HasColumnName("shortName")
                    .HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<Lecturers>(entity =>
            {
                entity.HasKey(e => e.LecturerId)
                    .HasName("PK_lecturers");

                entity.ToTable("lecturers");

                entity.Property(e => e.LecturerId).HasColumnName("lecturerID");

                entity.Property(e => e.Lecturer)
                    .IsRequired()
                    .HasColumnName("lecturer");
            });

            modelBuilder.Entity<Monitoring>(entity =>
            {
                entity.HasKey(e => e.CourseId)
                    .HasName("PK__Monitori__2AA84FD1DF4FDED1");

                entity.Property(e => e.CourseId)
                    .HasColumnName("courseId")
                    .ValueGeneratedNever();

                entity.Property(e => e.ClassActivity)
                    .HasColumnName("classActivity")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.ClassAttendance)
                    .HasColumnName("classAttendance")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.ContinuousAssessment)
                    .HasColumnName("continuousAssessment")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Essay)
                    .HasColumnName("essay")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.ExperimentalWork)
                    .HasColumnName("experimentalWork")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.OralExam)
                    .HasColumnName("oralExam")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.PracticalWork)
                    .HasColumnName("practicalWork")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Project)
                    .HasColumnName("project")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Report)
                    .HasColumnName("report")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Research)
                    .HasColumnName("research")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Seminar)
                    .HasColumnName("seminar")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.ShortTest)
                    .HasColumnName("shortTest")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.WrittenExam)
                    .HasColumnName("writtenExam")
                    .HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<StudentInformations>(entity =>
            {
                entity.HasKey(e => e.CourseId)
                    .HasName("PK__studentI__2AA84FD182B0D6FF");

                entity.ToTable("studentInformations");

                entity.Property(e => e.CourseId)
                    .HasColumnName("courseId")
                    .ValueGeneratedNever();

                entity.Property(e => e.GradingEvaluating)
                    .HasColumnName("gradingEvaluating")
                    .HasColumnType("varchar(max)");

                entity.Property(e => e.Recommended1)
                    .HasColumnName("recommended1")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Recommended2)
                    .HasColumnName("recommended2")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Recommended3)
                    .HasColumnName("recommended3")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Recommended4)
                    .HasColumnName("recommended4")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Recommended5)
                    .HasColumnName("recommended5")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Required1)
                    .HasColumnName("required1")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Required2)
                    .HasColumnName("required2")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Required3)
                    .HasColumnName("required3")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Required4)
                    .HasColumnName("required4")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Required5)
                    .HasColumnName("required5")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.StudentTasks)
                    .HasColumnName("studentTasks")
                    .HasColumnType("varchar(max)");

                entity.Property(e => e.Workload)
                    .HasColumnName("workload")
                    .HasColumnType("varchar(max)");
            });

            modelBuilder.Entity<TypeofClass>(entity =>
            {
                entity.HasKey(e => e.CourseId)
                    .HasName("PK__TypeofCl__2AA84FD1687BFA5A");

                entity.Property(e => e.CourseId)
                    .HasColumnName("courseId")
                    .ValueGeneratedNever();

                entity.Property(e => e.Distance)
                    .HasColumnName("distance")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Exercises)
                    .HasColumnName("exercises")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Field)
                    .HasColumnName("field")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Homework)
                    .HasColumnName("homework")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Lab)
                    .HasColumnName("lab")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Lectures)
                    .HasColumnName("lectures")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Mentoring)
                    .HasColumnName("mentoring")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Mixed)
                    .HasColumnName("mixed")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Multimedia)
                    .HasColumnName("multimedia")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.OtherCheck)
                    .HasColumnName("otherCheck")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.OtherText)
                    .HasColumnName("otherText")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Seminars)
                    .HasColumnName("seminars")
                    .HasColumnType("varchar(50)");
            });
        }

        public virtual DbSet<AdditionalInformations> AdditionalInformations { get; set; }
        public virtual DbSet<Assistents> Assistents { get; set; }
        public virtual DbSet<CourseAssistents> CourseAssistents { get; set; }
        public virtual DbSet<CourseLecturers> CourseLecturers { get; set; }
        public virtual DbSet<Courses> Courses { get; set; }
        public virtual DbSet<Details> Details { get; set; }
        public virtual DbSet<GeneralInformations> GeneralInformations { get; set; }
        public virtual DbSet<Lecturers> Lecturers { get; set; }
        public virtual DbSet<Monitoring> Monitoring { get; set; }
        public virtual DbSet<StudentInformations> StudentInformations { get; set; }
        public virtual DbSet<TypeofClass> TypeofClass { get; set; }
    }
}