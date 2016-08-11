using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OpisKolegija2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpisKolegija2.Controllers
{
    public class GeneralInformationsController : Controller
    {
        private CourseDescriptionTableContext _context;
        
        public int CourseId;

        public GeneralInformationsController(CourseDescriptionTableContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult Create(int id)
        {
            var Course = (from s1 in _context.Courses
                                where s1.CourseId == id
                                select s1).FirstOrDefault();
            ViewData["id"] = Course.CourseId;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(GeneralInformations GI)
        {
            if (ModelState.IsValid)
            {              
                _context.GeneralInformations.Add(GI);
                _context.SaveChanges();
                return RedirectToAction("Create", "Details", new { id = GI.CourseId });
            }

            return View(GI);
        }

        [HttpGet]
        public IActionResult Delete(int idCourse)
        {
            var Informations = (from s1 in _context.GeneralInformations
                            where s1.CourseId == idCourse
                            select s1).FirstOrDefault();

            _context.GeneralInformations.Remove(Informations);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            ViewData["id"] = id;
            GeneralInformations GI = (from s1 in _context.GeneralInformations
                                      where s1.CourseId == id
                                      select s1).FirstOrDefault();
            ViewBag.GeneralInfo = GI;
            return View();
        }

        [HttpPost]
        public IActionResult Update(GeneralInformations GI)
        {
            GeneralInformations query =
            (from s1 in _context.GeneralInformations
            where s1.CourseId == GI.CourseId
            select s1).FirstOrDefault();

            query.CourseId = GI.CourseId;
            query.Comments = GI.Comments;
            query.CourseCode = GI.CourseCode;
            query.CourseGoals = GI.CourseGoals;
            query.CourseStatus = GI.CourseStatus;
            query.CurriculumName = GI.CurriculumName;
            query.Ects = GI.Ects;
            query.HoursLab = GI.HoursLab;
            query.HoursLecture = GI.HoursLecture;
            query.HoursSeminar = GI.HoursSeminar;
            query.LearningOutcomes = GI.LearningOutcomes;
            query.Prerequisites = GI.Prerequisites;
            query.Semester = GI.Semester;
            query.ShortName = GI.ShortName;

            _context.SaveChanges() ;
            
            return RedirectToAction("Update","Details",new { id=GI.CourseId});
        }
    }
}
