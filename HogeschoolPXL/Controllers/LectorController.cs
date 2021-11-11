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
    public class LectorController : Controller
    {
        ApplicationDBContext _context;
        public LectorController(ApplicationDBContext context)
        {
            _context = context;
        }
        //Index pagina
        public IActionResult Index()
        {
            var lector = _context.Lectors.Include(a => a.Gebruiker);
            return View(lector.ToList());
        }
        //Nieuwe lector aanmaken
        public IActionResult Create()
        {
            //var student = new Student();
            var lector = new Lector();
            var gebruiker = _context.Gebruikers.OrderByDescending(x => x.GebruikerId).ToList();
            ViewBag.LastGebruiker = gebruiker;
            return View(lector);
        }
        public async Task<IActionResult> DetailsAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var lector = await _context.Lectors.Include(x => x.Gebruiker).FirstOrDefaultAsync(x => x.LectorId == id);
            if (lector == null)
            {
                return NotFound();
            }
            var lectorCard = new LectorCard(_context, lector);
            return View(lectorCard);
        }
        [HttpPost]
        public IActionResult Create(Gebruiker gebruiker)
        {
            if (ModelState.IsValid)
            {
                AddGebruiker((Gebruiker)gebruiker);
                return RedirectToAction("Index");
            }
            //Lector met gebruiker property's
            var lector = _context.Lectors.Include(a => a.Gebruiker);
            return View(lector.ToList());
        }
        private void AddGebruiker(Gebruiker lector)
        {
            //Gebruiker maken die een lector is
            Gebruiker g = (Gebruiker)lector;
            var l = new Lector() { Gebruiker = g }; ;
            _context.Gebruikers.Add(g);
            _context.Lectors.Add(l);
            _context.SaveChanges();
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var lector = await _context.Lectors.Include(x => x.Gebruiker).FirstOrDefaultAsync(x => x.LectorId == id);
            if (lector == null)
            {
                return NotFound();
            }
            var lectorCard = new LectorCard(_context, lector);
            return View(lectorCard);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lector = await _context.Lectors.FindAsync(id);
            _context.Lectors.Remove(lector);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
