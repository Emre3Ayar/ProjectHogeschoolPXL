using HogeschoolPXL.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HogeschoolPXL.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private ApplicationDBContext _context;
        public NavigationMenuViewComponent(ApplicationDBContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["StudiePunten"];
            return View(_context.Vakken.Select(x => x.StudiePunten).Distinct().OrderBy(x => x));
        }
    }
}
