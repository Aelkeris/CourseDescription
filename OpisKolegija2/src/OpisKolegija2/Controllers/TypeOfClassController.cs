using Microsoft.AspNetCore.Mvc;
using OpisKolegija2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpisKolegija2.Controllers
{
    public class TypeOfClassController : Controller
    {
        private CourseDescriptionTableContext _context;
       

        public TypeOfClassController(CourseDescriptionTableContext context)
        {
            _context = context;
        }

       

        [HttpGet]
        public IActionResult Create(int id)
        {
            ViewData["id"] = id;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TypeofClass _a)
        {
            if (ModelState.IsValid)
            {
                
                _context.TypeofClass.Add(_a);
                _context.SaveChanges();
                return RedirectToAction("Create","Monitoring",new { id=_a.CourseId });
            }

            return View(_a);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            TypeofClass TOC = (from s1 in _context.TypeofClass
                               where s1.CourseId == id
                               select s1).FirstOrDefault();
            ViewData["id"] = id;
            ViewBag.TOC = TOC;
            return View(TOC);
        }

        [HttpPost]
        public IActionResult Update(TypeofClass toc)
        {
            TypeofClass TOC = (from s1 in _context.TypeofClass
                           where s1.CourseId == toc.CourseId 
                           select s1).FirstOrDefault();

            TOC.Distance=toc.Distance;
            TOC.Exercises=toc.Exercises;
            TOC.Field = toc.Field;
            TOC.Homework=toc.Homework;
            TOC.Lab=toc.Lab;
            TOC.Lectures=toc.Lectures;
            TOC.Mentoring=toc.Mentoring;
            TOC.Mixed=toc.Mixed;
            TOC.Multimedia=toc.Multimedia;
            TOC.OtherCheck=toc.OtherCheck;
            TOC.Seminars=toc.Seminars;
            TOC.OtherText=toc.OtherText;

            _context.SaveChanges();


            return RedirectToAction("Update", "Monitoring", new { id = toc.CourseId });
        }

    }
}
