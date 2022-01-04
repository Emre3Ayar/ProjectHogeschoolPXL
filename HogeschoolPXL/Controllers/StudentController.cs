using HogeschoolPXL.Data;
using HogeschoolPXL.Data.Tables;
using HogeschoolPXL.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HogeschoolPXL.Controllers
{
    [Authorize]
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
        #region Detailpagina Student
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
        #endregion
        #region Nieuwe Student aanmaken
        public IActionResult Create()
        {
            //var student = new Student();
            var student = new Student();
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
        #endregion
        #region Student verwijderen
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
        #endregion
        #region Student aanpassen
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            var student = _context.Students.Include(x => x.Gebruiker).FirstOrDefault(x => x.StudentId == id);
            var studentCard = new StudentCard(_context, student);
            
            return View(studentCard);
        }
        public async Task<IActionResult> Edit(Gebruiker gebruiker)
        {
            var id = gebruiker.GebruikerId;
            var test = gebruiker.Naam;
            if (ModelState.IsValid)
            {
                Gebruiker Updategebruiker = await _context.Gebruikers.FindAsync(id);
                Updategebruiker.Naam = gebruiker.Naam;
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }
        #endregion
        public async Task<IActionResult> InschrijvingAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var student = await _context.Students.Include(x => x.Gebruiker).FirstOrDefaultAsync(x => x.StudentId == id);
            var inschrijving = new Inschrijving
                {
                StudentId = student.StudentId, 
                
            };
            ViewData["VakId"] = new SelectList(_context.Vakken, "VakId", "VakNaam");
            _context.Inschrijvingen.Add(inschrijving);
            var studentCard = new StudentCard(_context, student);
            return View(studentCard);
        }
    }
}
