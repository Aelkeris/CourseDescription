using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OpisKolegija2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpisKolegija2.Controllers
{
    public class CourseAssistentsController : Controller
    {
        private CourseDescriptionTableContext _context;

        public CourseAssistentsController(CourseDescriptionTableContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.CourseAssistents.Include(c => c.Courses).Include(c => c.Assistents).ToList());
        }

        public IActionResult Create()
        {

            //Ovaj viewbag služi zato da dobijemo imena iz ID-eva za selektiranje 
            ViewBag.v = _context.Courses.Select(x => new Courses
            {
                CourseId = x.CourseId,
                CourseTitle = x.CourseTitle
            }).ToList();

            ViewBag.c = _context.Assistents.Select(y => new Assistents
            {
                AssistentId = y.AssistentId,
                Assistent = y.Assistent
            }).ToList();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CourseAssistents cs)
        {
            if (ModelState.IsValid)
            {
                _context.CourseAssistents.Add(cs);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cs);
        }

        [HttpGet]
        public IActionResult Delete(int _idCourse,int _idAssistent)
        {

            var link = (from s1 in _context.CourseAssistents
                        where s1.CourseId == _idCourse && s1.AssistentId == _idAssistent
                        select s1).FirstOrDefault();

            //Delete it from memory
            _context.CourseAssistents.Remove(link);
            //Save to database           
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
