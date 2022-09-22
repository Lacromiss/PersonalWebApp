using Microsoft.AspNetCore.Mvc;
using PersonalWebApp.Dal;
using PersonalWebApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace PersonalWebApp.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class MeController : Controller
    {
        private readonly AppDbContext _context;

        public MeController(AppDbContext context )
        {
            _context = context;

        }
        public IActionResult Index()
        {
          List<Me> me = _context.mes.ToList();
            return View(me);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]

        public IActionResult Create(Me me)
        {
            if (!ModelState.IsValid)
            {
                return View();

            }
            _context.mes.Add(me);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
       
    }
}
