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
        //Nieuwe handboek aanmaken
        public IActionResult Create()
        {
            var handboek = new Handboek();
            return View(handboek);
        }
        public IActionResult Details(int id)
        {
            var handboek = _context.Handboeken.Where(x => x.HandboekId == id).FirstOrDefault();
            return View(handboek);
        }
        [HttpPost]
        public IActionResult Create(Gebruiker gebruiker)
        {
            if (ModelState.IsValid)
            {
            }
            return View("Index");
        }
    }
}
