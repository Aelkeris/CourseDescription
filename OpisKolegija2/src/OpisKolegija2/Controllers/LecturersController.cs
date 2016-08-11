using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OpisKolegija2.Models;
using Microsoft.AspNetCore.Mvc;


namespace OpisKolegija2.Controllers
{
    public class LecturersController : Controller
    {
        private CourseDescriptionTableContext _context;

        public LecturersController(CourseDescriptionTableContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Lecturers.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Lecturers lecturers)
        {
            if (ModelState.IsValid)
            {
                _context.Lecturers.Add(lecturers);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lecturers);
        }

        [HttpGet]
        public IActionResult Delete(int idLecturer)
        {
            var Lecturer = (from s1 in _context.Lecturers
                        where s1.LecturerId == idLecturer
                        select s1).FirstOrDefault();

            var Veze = (from s2 in _context.CourseLecturers
                        where s2.LecturerId == idLecturer
                        select s2);

            for (int i=0;i<Veze.Count();i++)
            {
                CourseLecturers cl = Veze.ToList().ElementAt(i);
                _context.CourseLecturers.Remove(cl);
            }

            _context.Lecturers.Remove(Lecturer);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}