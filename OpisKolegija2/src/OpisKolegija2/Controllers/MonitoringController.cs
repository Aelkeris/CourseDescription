using Microsoft.AspNetCore.Mvc;
using OpisKolegija2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpisKolegija2.Controllers
{
    public class MonitoringController : Controller
    {
        private CourseDescriptionTableContext _context;
        int CourseId;

        public MonitoringController(CourseDescriptionTableContext context)
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
        public IActionResult Create(Monitoring _a)
        {
            if (ModelState.IsValid)
            {
                
                _context.Monitoring.Add(_a);
                _context.SaveChanges();
                return RedirectToAction("Create","StudentInformations",new { id = _a.CourseId});
            }

            return View(_a);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            Monitoring Mon = (from s1 in _context.Monitoring
                               where s1.CourseId == id
                               select s1).FirstOrDefault();
            ViewData["id"] = id;
            ViewBag.Monitoring = Mon;
            return View();
        }

        [HttpPost]
        public IActionResult Update(Monitoring mon)
        {
            Monitoring MON = (from s1 in _context.Monitoring
                               where s1.CourseId == mon.CourseId
                               select s1).FirstOrDefault();

            MON.ClassActivity = mon.ClassActivity;
            MON.ClassAttendance = mon.ClassAttendance;
            MON.ContinuousAssessment = mon.ContinuousAssessment;
            MON.Essay = mon.Essay;
            MON.ExperimentalWork = mon.ExperimentalWork;
            MON.OralExam = mon.OralExam;
            MON.PracticalWork = mon.PracticalWork;
            MON.Project = mon.Project;
            MON.Report = mon.Report;
            MON.Research = mon.Research;
            MON.Seminar = mon.Seminar;
            MON.ShortTest = mon.ShortTest;
            MON.WrittenExam = mon.WrittenExam;

            _context.SaveChanges();


            return RedirectToAction("Update", "StudentInformations", new { id = mon.CourseId });
        }
    }
}
