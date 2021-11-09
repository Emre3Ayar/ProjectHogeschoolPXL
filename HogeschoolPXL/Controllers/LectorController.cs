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
            var lector = new Lector();
            return View(lector);
        }
        public IActionResult Details(int id)
        {
            var lector = _context.Lectors.Where(x => x.LectorId == id).FirstOrDefault();
            return View(lector);
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
            var l = new Lector();
            _context.Gebruikers.Add(g);
            _context.Lectors.Add(l);
            _context.SaveChanges();
        }
    }
}
