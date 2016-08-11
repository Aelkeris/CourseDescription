using Microsoft.AspNetCore.Mvc;
using OpisKolegija2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpisKolegija2.Controllers
{
    public class StudentInformationsController : Controller
    {
        private CourseDescriptionTableContext _context;
      

        public StudentInformationsController(CourseDescriptionTableContext context)
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
        public IActionResult Create(StudentInformations _a)
        {
            if (ModelState.IsValid)
            {
                
                _context.StudentInformations.Add(_a);
                _context.SaveChanges();
                return RedirectToAction("Create","AdditionalInformations", new { id = _a.CourseId});
            }

            return View(_a);
        }

        

        [HttpGet]
        public IActionResult Update(int id)
        {
            StudentInformations StudInfo = (from s1 in _context.StudentInformations
                               where s1.CourseId == id
                               select s1).FirstOrDefault();
            ViewData["id"] = id;
            ViewBag.StudInfo = StudInfo;
            return View();
        }

        [HttpPost]
        public IActionResult Update(StudentInformations sti)
        {
            StudentInformations STI = (from s1 in _context.StudentInformations
                               where s1.CourseId == sti.CourseId
                               select s1).FirstOrDefault();

            STI.GradingEvaluating = sti.GradingEvaluating;
            STI.Recommended1 = sti.Recommended1;
            STI.Recommended1 = sti.Recommended2;
            STI.Recommended1 = sti.Recommended3;
            STI.Recommended1 = sti.Recommended4;
            STI.Recommended1 = sti.Recommended5;
            STI.Required1 = sti.Required1;
            STI.Required2 = sti.Required2;
            STI.Required3 = sti.Required3;
            STI.Required4 = sti.Required4;
            STI.Required5 = sti.Required5;
            STI.StudentTasks = sti.StudentTasks;
            STI.Workload = sti.Workload;
            

            _context.SaveChanges();


            return RedirectToAction("Update", "AdditionalInformations", new { id = sti.CourseId });
        }
    }
}
