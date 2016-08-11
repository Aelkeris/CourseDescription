using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OpisKolegija2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpisKolegija2.Controllers
{
    public class CoursesController : Controller
    {
        private CourseDescriptionTableContext _context;

        public CoursesController(CourseDescriptionTableContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var c = _context.Courses.FromSql("SELECT * FROM dbo.Courses").ToList();
            
            List<List<string>> ss = new List<List<string>>();

            for (int i = 0; i < c.Count(); i++)
            {
                List<string> s = new List<string>();

                Courses course = c.ElementAt(i);
                int Id = course.CourseId;
                string query = "SELECT t1.LecturerId,Lecturer FROM lecturers t1 JOIN courseLecturers t2 ON t1.LecturerId = t2.LecturerId JOIN courses t3 ON t2.courseId = t3.CourseId WHERE t3.CourseId = {0}";

                var ProfesoriPredmeta = _context.Lecturers.FromSql(query, Id).ToList();
                //dodati if koji će puniti listu sa praznim podatcima 
                if (ProfesoriPredmeta.Count() == 0)
                {
                    ss.Add(new List<string>());
                }
                else
                {
                    for (int l = 0; l < ProfesoriPredmeta.Count(); l++)
                    {
                        s.Add(ProfesoriPredmeta.ElementAt(l).Lecturer.ToString());
                    }
                    ss.Add(s);
                }
            }
            ViewBag.Popis = ss;

            List<CoursesViewModel> ListOfViewModels = new List<CoursesViewModel>();
            List<Courses> ListOfCourses = _context.Courses.ToList();
            for(int x=0;x<_context.Courses.Count();x++)
            {
                CoursesViewModel cvm = new CoursesViewModel
                {
                    id = ListOfCourses.ElementAt(x).CourseId,
                    nazivPredmeta = ListOfCourses.ElementAt(x).CourseTitle,
                    profesori = ss.ElementAt(x)
                };
                ListOfViewModels.Add(cvm);
            }
            


            return View(ListOfViewModels);
        }

       
        public IActionResult Create(int id)
        {
            ViewBag.x = _context.Lecturers.Select(x => new Lecturers
            {
                LecturerId = x.LecturerId,
                Lecturer = x.Lecturer
            }).ToList();

            ViewBag.y = _context.Assistents.Select(y => new Assistents
            {
                AssistentId = y.AssistentId,
                Assistent = y.Assistent
            }).ToList();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //Create metoda koja prima poseban viewmodel (CLA) sa informacijama o selektiranim profesorima
        //asistentima, i naslovu predmeta
        public IActionResult Create(CLA Info)
        {
            if (ModelState.IsValid)
            {
                //Inicijaliziranje svih objekata koji će se zapravo upisati u bazu
                Courses courses = new Courses();
                CourseAssistents CA = new CourseAssistents();
                CourseLecturers CL = new CourseLecturers();

                //Postavljanje naziva Predmeta u predmet koji će se upisati u bazu
                //i postavljanje id u 0 tako da se baza pobrine za njega
                courses.CourseTitle = Info.CourseTitle;
                courses.CourseId = 0;
                //dodavanje tog predmeta u bazu kako bi mogli dobiti id, kojega ćemo povezati sa profesorima
                //i asistentima
                _context.Courses.Add(courses);
                _context.SaveChanges();

                //selektiranje ID-a upisanog predmeta
                var Course = (from s1 in _context.Courses
                            where s1.CourseTitle == courses.CourseTitle
                            select s1).FirstOrDefault();

                int CourseId = Course.CourseId;

                //spremanje velicina polja za profesore i asistente za pravi broj iteracija
                int BrojOdabranihProfesora = Info.LecturerId.Count();
                int BrojOdabranihAsistenata = Info.AssistentId.Count();

                //stvaraju se veze između predmeta i svakog profesora posebno 
                for(int i=0;i<BrojOdabranihAsistenata;i++)
                {
                    CA.CourseId = CourseId;
                    CA.AssistentId = Info.AssistentId[i];

                    _context.CourseAssistents.Add(CA);
                    _context.SaveChanges();
                }
                for(int j=0;j<BrojOdabranihProfesora;j++)
                {
                    CL.CourseId = CourseId;
                    CL.LecturerId = Info.LecturerId[j];

                    _context.CourseLecturers.Add(CL);
                    _context.SaveChanges();
                }


                //provjeri da li redirecttoaction vodi ka post ili get metodi
                return RedirectToAction("Create","GeneralInformations",new { id = CourseId});
            }

            return View();
        }
        
        [HttpGet]
        public IActionResult Delete(int id)
        {
            //Kada ostatak modela iz baze bude rješen, onda se trebam vratiti na ovu metodu
            //i implementirati brisanje svega što ima određeni id iz baze.
            Courses course = (from s1 in _context.Courses
                              where s1.CourseId == id
                              select s1).FirstOrDefault();
            _context.Courses.Remove(course);

            GeneralInformations generalInformations = (from s1 in _context.GeneralInformations
                                                       where s1.CourseId == id
                                                       select s1).FirstOrDefault();
            _context.GeneralInformations.Remove(generalInformations);

            var Details = from s1 in _context.Details
                          where s1.CourseId == id
                          select s1;
            for(int i =0;i< Details.Count();i++)
            {
                Details details = Details.ToList().ElementAt(i);
                _context.Details.Remove(details);
            }

            TypeofClass TypeOfClass = (from s1 in _context.TypeofClass
                                       where s1.CourseId == id
                                       select s1).FirstOrDefault();
            _context.TypeofClass.Remove(TypeOfClass);

            Monitoring monitoring = (from s1 in _context.Monitoring
                                     where s1.CourseId == id
                                     select s1).FirstOrDefault();

            _context.Monitoring.Remove(monitoring);

            StudentInformations studentInformations = (from s1 in _context.StudentInformations
                                                       where s1.CourseId == id
                                                       select s1).FirstOrDefault();

            _context.StudentInformations.Remove(studentInformations);

            AdditionalInformations additionalInformations = (from s1 in _context.AdditionalInformations
                                                             where s1.CourseId == id
                                                             select s1).FirstOrDefault();

            _context.AdditionalInformations.Remove(additionalInformations);

            var CL = from s1 in _context.CourseLecturers
                          where s1.CourseId == id
                          select s1;
            for (int i = 0; i < CL.Count(); i++)
            {
                CourseLecturers cl = CL.ToList().ElementAt(i);
                _context.CourseLecturers.Remove(cl);
            }

            var CA = from s1 in _context.CourseAssistents
                     where s1.CourseId == id
                     select s1;
            for (int i = 0; i < CA.Count(); i++)
            {
                CourseAssistents ca = CA.ToList().ElementAt(i);
                _context.CourseAssistents.Remove(ca);
            }

            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
