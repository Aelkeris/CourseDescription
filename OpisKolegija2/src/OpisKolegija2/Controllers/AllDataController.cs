using Microsoft.AspNetCore.Mvc;
using OpisKolegija2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpisKolegija2.Controllers
{
    public class AllDataController : Controller
    {
        private CourseDescriptionTableContext _context;

        public AllDataController(CourseDescriptionTableContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index(int id)
        {
            //Dohvaćam listu predavača za taj predmet, i spremam ga(kasnije u kodu, u AllDataModel)
            List<Lecturers> Lecturers =new List<Lecturers>();
            var CourseLecturers = (from s1 in _context.CourseLecturers
                                   where s1.CourseId == id
                                   select s1);
            List<CourseLecturers> CourseLecturersList = CourseLecturers.ToList();

            for(int i =0;i<CourseLecturersList.Count();i++)
            {
                CourseLecturers elementLecturer = CourseLecturersList.ElementAt(i);
                int elementIdLecturers = elementLecturer.LecturerId;
                Lecturers Lecturer = (from s1 in _context.Lecturers
                                where s1.LecturerId == elementIdLecturers
                                      select s1).FirstOrDefault();
                Lecturers.Add(Lecturer);
            }
            //Isto sto sam imao za predavace sada treba napraviti za asistente
            List<Assistents> Assistents = new List<Assistents>();
            var CourseAssistents = (from s1 in _context.CourseAssistents
                                  where s1.CourseId == id
                                  select s1);
            List<CourseAssistents> CourseAssistentsList = CourseAssistents.ToList();

            for(int j =0;j<CourseAssistentsList.Count();j++)
            {
                CourseAssistents elementAssistent = CourseAssistentsList.ElementAt(j);
                int elementIdAssistent = elementAssistent.AssistentId;
                Assistents Assistent = (from s1 in _context.Assistents
                                        where s1.AssistentId == elementIdAssistent
                                        select s1).FirstOrDefault();
                Assistents.Add(Assistent);
            }
            //dohvat svih details elemenata za taj predmet
            var Details = (from s1 in _context.Details
                           where s1.CourseId == id
                           select s1);
            List<Details> DetailsList = Details.ToList();

            //Dohvat Course elementa
            //nafilaj alldatu sa svim podatcima koji imaju id koji ti treba
            Courses Courses = (from s1 in _context.Courses
                               where s1.CourseId == id
                               select s1).FirstOrDefault();

            GeneralInformations GeneralInformations = (from s1 in _context.GeneralInformations
                                       where s1.CourseId == id
                                       select s1).FirstOrDefault();

            TypeofClass TypeOfClass = (from s1 in _context.TypeofClass
                               where s1.CourseId == id
                               select s1).FirstOrDefault();

            Monitoring Monitoring = (from s1 in _context.Monitoring
                              where s1.CourseId == id
                              select s1).FirstOrDefault();

            StudentInformations StudentInformations = (from s1 in _context.StudentInformations
                                       where s1.CourseId == id
                                       select s1).FirstOrDefault();
            AdditionalInformations AdditionalInformations = (from s1 in _context.AdditionalInformations
                                          where s1.CourseId == id
                                          select s1).FirstOrDefault();

            AllData AllData = new AllData();
            AllData.AdditionalInformations = AdditionalInformations;
            AllData.TypeofClass = TypeOfClass;
            AllData.StudentInformations = StudentInformations;
            AllData.GeneralInformations = GeneralInformations;
            AllData.AssistentsList = Assistents;
            AllData.LecturersList = Lecturers;
            AllData.Monitoring = Monitoring;
            AllData.DetailsList = DetailsList;
            AllData.Courses = Courses;

            ViewBag.AllData = AllData;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(AllData _a)
        {
            return View();
        }

        [HttpGet]
        public IActionResult Update()
        {
            return View();
        }
    }
}
