using HogeschoolPXL.Data;
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
    }
}
