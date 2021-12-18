using HogeschoolPXL.Data;
using HogeschoolPXL.Data.Tables;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HogeschoolPXL.Controllers
{
    public class VakController : Controller
    {
        ApplicationDBContext _context;
        public VakController(ApplicationDBContext context)
        {
            _context = context;
        }
        //Index pagina
        public IActionResult Index()
        {
            var vak = _context.Vakken.Include(x => x.Handboek);
            return View(vak.ToList());
        }
        public IActionResult Details(int id)
        {
            var vak = _context.Vakken.Where(x => x.VakId == id).FirstOrDefault();
            return View(vak);
        }
        //Nieuwe vak aanmaken
        [HttpGet]
        public IActionResult Create()
        {
            var vak = new Vak();
            ViewData["HandboekId"] = new SelectList(_context.Handboeken, "HandboekId", "Titel");
            return View(vak);
        }
        //aanmaken handboek
        [HttpPost]
        public IActionResult Create(Vak vak)
        {
            if (ModelState.IsValid)
            {
                AddVak((Vak)vak);
                return RedirectToAction("Index");
            }
            //Lector met gebruiker property's
            return View(vak);
        }
        private void AddVak(Vak vak)
        {
            //Handboek aanmaken is
            Vak v = (Vak)vak;
            //var h = new Handboek();
            _context.Vakken.Add(v);
            _context.SaveChanges();
        }
        //handboek verwijderen
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var vak = await _context.Vakken.FirstOrDefaultAsync(x => x.VakId == id);

            if (vak == null)
            {
                return NotFound();
            }
            return View(vak);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vak = await _context.Vakken.FindAsync(id);
            if (vak == null)
            {
                return NotFound();
            }
            _context.Vakken.Remove(vak);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        #region Vak aanpassen
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            var vak = _context.Vakken.FirstOrDefault(x => x.VakId == id);

            return View(vak);
        }
        public async Task<IActionResult> Edit(Vak vak)
        {
            if (ModelState.IsValid)
            {
                _context.Vakken.Update(vak);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }
        #endregion
    }
}
