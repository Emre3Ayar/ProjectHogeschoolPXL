using HogeschoolPXL.Data;
using HogeschoolPXL.Data.Tables;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HogeschoolPXL.Controllers
{
    [Authorize(Roles = "STUDENT,ADMIN,LECTOR")]
    public class HandboekController : Controller
    {
        ApplicationDBContext _context;
        public HandboekController(ApplicationDBContext context)
        {
            _context = context;
        }
        //Index pagina
        public IActionResult Index()
        {
            var handboek = _context.Handboeken;
            return View(handboek);
        }
        //Detail van een Handboek
        public IActionResult Details(int id)
        {
            var handboek = _context.Handboeken.Where(x => x.HandboekId == id).FirstOrDefault();
            return View(handboek);
        }
        //Nieuwe handboek aanmaken
        [HttpGet]
        public IActionResult Create()
        {
            var handboek = new Handboek();
            return View(handboek);
        }       
        //aanmaken handboek
        [HttpPost]
        public IActionResult Create(Handboek handboek)
        {           
            if (ModelState.IsValid)
            {
                AddHandboek((Handboek)handboek);
                return RedirectToAction("Index");
            }
            //Lector met gebruiker property's
            return View(handboek);
        }
        private void AddHandboek(Handboek handboek)
        {
            //Handboek aanmaken is
            Handboek h = (Handboek)handboek;
            //var h = new Handboek();
            _context.Handboeken.Add(h);
            _context.SaveChanges();
        }
        //handboek verwijderen
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var handboek = await _context.Handboeken.FirstOrDefaultAsync(x => x.HandboekId == id);

            if (handboek == null)
            {
                return NotFound();
            }
            return View(handboek);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var handboek = await _context.Handboeken.FindAsync(id);
            if (handboek == null)
            {
                return NotFound();
            }
            _context.Handboeken.Remove(handboek);
            var handboeknaam = handboek.Titel;
            var handboekid = handboek.HandboekId;

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
