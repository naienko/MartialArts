using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MartialArts.Models;
using MartialArts.Models.ViewModels;
using MartialArts.Data;

namespace MartialArts.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            IndexModel frontPage = new IndexModel
            {
                Students = _context.Student.Where(s => s.Active == true).ToList(),
                Events = _context.Event.Where(e => e.StartTime > DateTime.Now).OrderByDescending(e => e.StartTime).ToList()
            };
            return View(frontPage);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
