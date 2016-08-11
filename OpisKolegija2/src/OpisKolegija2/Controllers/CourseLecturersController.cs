using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OpisKolegija2.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpisKolegija2.Controllers
{
    public class CourseLecturersController : Controller
    {
        private CourseDescriptionTableContext _context;

        public CourseLecturersController(CourseDescriptionTableContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
           
           return View(_context.CourseLecturers.Include(c => c.Courses).Include(c => c.Lecturers).ToList());
        }

        public IActionResult Create()
        {

            //Ovaj viewbag služi zato da dobijemo imena iz ID-eva za selektiranje 
            ViewBag.v = _context.Courses.Select(x => new Courses
            {
                CourseId = x.CourseId,
                CourseTitle = x.CourseTitle
            }).ToList();

            ViewBag.c = _context.Lecturers.Select(y => new Lecturers
            {
                LecturerId = y.LecturerId,
                Lecturer = y.Lecturer
            }).ToList();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CourseLecturers cl)
        {
            if (ModelState.IsValid)
            {
                _context.CourseLecturers.Add(cl);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cl);
        }

        [HttpGet]
        public IActionResult Delete(int _idLecturer,int _idCourse)
        {

            var link = (from s1 in _context.CourseLecturers
                        where s1.CourseId == _idCourse && s1.LecturerId==_idLecturer
                        select s1).FirstOrDefault();
           
            //Delete it from memory
            _context.CourseLecturers.Remove(link);
            //Save to database           
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
