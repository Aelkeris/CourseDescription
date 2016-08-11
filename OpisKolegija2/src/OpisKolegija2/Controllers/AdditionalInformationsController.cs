using Microsoft.AspNetCore.Mvc;
using OpisKolegija2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpisKolegija2.Controllers
{
    public class AdditionalInformationsController : Controller
    {
        private CourseDescriptionTableContext _context;
      

        public AdditionalInformationsController(CourseDescriptionTableContext context)
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
        public IActionResult Create(AdditionalInformations _a)
        {
            if (ModelState.IsValid)
            {
                
                _context.AdditionalInformations.Add(_a);
                _context.SaveChanges();
                return RedirectToAction("Index","Courses");
            }

            return View(_a);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            AdditionalInformations AddInfo = (from s1 in _context.AdditionalInformations
                                            where s1.CourseId == id
                                            select s1).FirstOrDefault();
            ViewData["id"] = id;
            ViewBag.AddInfo = AddInfo;
            return View();
        }

        [HttpPost]
        public IActionResult Update(AdditionalInformations adi)
        {
            AdditionalInformations ADI = (from s1 in _context.AdditionalInformations
                                       where s1.CourseId == adi.CourseId
                                       select s1).FirstOrDefault();

            ADI.Attendance = adi.Attendance;
            ADI.ClassInformation = adi.ClassInformation;
            ADI.ContactingTeacher = adi.ContactingTeacher;
            ADI.Other = adi.Other;
            ADI.WrittenWork = adi.WrittenWork;


            _context.SaveChanges();


            return RedirectToAction("Index", "Alldata", new { id = adi.CourseId });
        }

    }
}
