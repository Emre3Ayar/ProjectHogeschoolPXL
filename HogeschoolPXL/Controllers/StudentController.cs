using HogeschoolPXL.Data;
using HogeschoolPXL.Data.Tables;
using HogeschoolPXL.ViewModels;
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
        public async Task<IActionResult> DetailsAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var student = await _context.Students.Include(x => x.Gebruiker).FirstOrDefaultAsync(x => x.StudentId == id);
            if (student == null)
            {
                return NotFound();
            }
            var studentCard = new StudentCard(_context, student);
            return View(studentCard);
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
        public async Task<IActionResult> Delete (int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var student = await _context.Students.Include(x => x.Gebruiker).FirstOrDefaultAsync(x => x.StudentId == id);
            if (student == null)
            {
                return NotFound();
            }
            var studentCard = new StudentCard(_context, student);
            return View(studentCard);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student = await _context.Students.FindAsync(id);
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var student = await _context.Students.Include(x => x.Gebruiker).FirstOrDefaultAsync(x => x.StudentId == id);
            var studentCard = new StudentCard(_context, student);
            return View(studentCard);
        }    
        public IActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Gebruikers.Update(student.Gebruiker);
                _context.Students.Update(student);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction("Index");
        }
        private bool StudentExists(int id)
        {
            return _context.Students.Any(x => x.StudentId == id);
        }
    }
}
