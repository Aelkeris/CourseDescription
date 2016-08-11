using Microsoft.AspNetCore.Mvc;
using OpisKolegija2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpisKolegija2.Controllers
{
    public class DetailsController : Controller
    {
        private CourseDescriptionTableContext _context;
       

        public DetailsController(CourseDescriptionTableContext context)
        {
            _context = context;
        }

        public IActionResult Index(int id)
        {
            var link = (from s1 in _context.Details
                        where s1.CourseId == id
                        select s1).FirstOrDefault();
            ViewBag.v = link;
            return View();
        }

        [HttpGet]
        public IActionResult Create(int id)
        {
            
            var Course = (from s1 in _context.Courses
                          where s1.CourseId == id
                          select s1).FirstOrDefault();
            ViewData["id"] = Course.CourseId;
            
            var DetailsList = (from s2 in _context.Details
                               where s2.CourseId == id
                               select s2).ToList();

            int BrojTjedna = DetailsList.Count+1;
            ViewData["brojTjedna"] = BrojTjedna;

            ViewBag.DL = DetailsList;
            if(DetailsList.Count()==15)
            {
                return RedirectToAction("Create", "TypeOfClass",new { id = Course.CourseId});
            }
            return View("Create");
        }

       

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Details _a)
        {
            if (ModelState.IsValid)
            {
                //_a.CourseId = CourseId;
                _a.Id = 0;
                _context.Details.Add(_a);
                _context.SaveChanges();
                return RedirectToAction("Create", "Details", new { id = _a.CourseId });
            }

            return View(_a);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            ViewData["id"] = id;
            var DetailsList = (from s2 in _context.Details
                               where s2.CourseId == id
                               select s2).ToList();

            ViewBag.DL = DetailsList;
            return View();
        }

        [HttpPost]
        public IActionResult Update(Details details)
        {
            Details det = (from s1 in _context.Details
                           where s1.CourseId == details.CourseId && s1.WeekNo == details.WeekNo
                           select s1).FirstOrDefault();
            if(details.WeekNo==null)
            {
                return RedirectToAction("Update", "TypeOfClass", new { id = details.CourseId });
            }

            det.Hours = details.Hours;
            det.Description1 = details.Description1;
            det.Description2 = details.Description2;
            det.Description3 = details.Description3;

            _context.SaveChanges();

            return RedirectToAction("Update","TypeOfClass",new { id = details.CourseId});
        }
    }
}
