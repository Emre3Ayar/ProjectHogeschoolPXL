using HogeschoolPXL.Data;
using HogeschoolPXL.Data.Tables;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HogeschoolPXL.Controllers
{
    public class StudentController : Controller
    {
        ApplicationDBContext _context;
        public StudentController(ApplicationDBContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }
        //Index pagina
        public IActionResult Index()
        {
            var student = _context.Students.Include(a => a.Gebruiker);
            return View(student.ToList());
        }
        //Nieuwe student aanmaken
        public IActionResult Create()
        {
            //var student = new Student();
            var student = new Student();
            var gebruiker =  _context.Gebruikers.OrderByDescending(x => x.GebruikerId).ToList();
            ViewBag.LastGebruiker = gebruiker;
            return View(student);
        }
        public IActionResult Details(int id)
        {
            var student = _context.Students.Where(x => x.StudentId == id).FirstOrDefault();
            return View(student);
        }
        [HttpPost]
        public IActionResult Create(Gebruiker gebruiker)
        {
            if (ModelState.IsValid)
            {
                AddGebruiker((Gebruiker)gebruiker);
                return RedirectToAction("Index");
            }
            //Student met gebruiker property's
            var student = _context.Students.Include(a => a.Gebruiker);
            return View(student.ToList());
        }
        private void AddGebruiker(Gebruiker student)
        {
            //Gebruiker maken die een student is
            Gebruiker g = (Gebruiker) student;
            var s = new Student { Gebruiker = g};
            _context.Gebruikers.Add(g);
            _context.Students.Add(s);
            _context.SaveChanges();
        }
    }
}
