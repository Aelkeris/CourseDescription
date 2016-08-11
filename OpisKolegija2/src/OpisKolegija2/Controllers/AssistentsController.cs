using Microsoft.AspNetCore.Mvc;
using OpisKolegija2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpisKolegija2.Controllers
{
    public class AssistentsController : Controller
    {
        private CourseDescriptionTableContext _context;

        public AssistentsController(CourseDescriptionTableContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Assistents.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Assistents _a)
        {
            if (ModelState.IsValid)
            {
                _context.Assistents.Add(_a);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(_a);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var link = (from s1 in _context.Assistents
                        where s1.AssistentId == id 
                        select s1).FirstOrDefault();

            //Delete it from memory
            _context.Assistents.Remove(link);
            //Save to database           
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

