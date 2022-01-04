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
    public class InschrijvingController : Controller
    {
        ApplicationDBContext _context;
        public InschrijvingController(ApplicationDBContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }
        public IActionResult Index()
        {
            var inschrijving = _context.Inschrijvingen.Include(a => a.Student.Gebruiker);
            var academiejaar = _context.Inschrijvingen.Include(a => a.AcademieJaar);
            //ViewData["AcademieJaarId"] = new SelectList(_context.AcademieJaren, "AcademieJaarId","StartDatum");
            return View(inschrijving.ToList());
        }
        //public  IActionResult Create()
        //{
        //    var inschrijving = new Inschrijving();
        //    //_context.Gebruikers.ToList();
        //    ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "StudentId");
        //    return View(inschrijving);
        //}
        //[HttpPost]
        //public IActionResult Create(Inschrijving inschrijving)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Inschrijvingen.Add(inschrijving);
        //        return RedirectToAction("Index");
        //    }
        //    return View(inschrijving);
        //}
    }
}
