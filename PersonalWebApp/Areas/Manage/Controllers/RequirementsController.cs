using Microsoft.AspNetCore.Mvc;
using PersonalWebApp.Dal;
using PersonalWebApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace PersonalWebApp.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class RequirementsController : Controller
    {
        private readonly AppDbContext _context;

        public RequirementsController(AppDbContext context)
        {
            _context = context;

        }
        public IActionResult Index()
        {
            List<Science> science = _context.sciences.ToList();
            return View(science);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Science science)
        {
            if (!ModelState.IsValid)
            {
                return View();

            }
            science.ProfilId = 3;
            _context.sciences.Add(science);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Update(int Id)
        {
            var a = _context.sciences.Find(Id);
            if (a==null)
            {
                return NotFound();

            }
            return View(a);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int Id,Science science)
        {
            var a = _context.sciences.Find(Id);
            if (a == null)
            {
                return NotFound();

            }
            a.Name = science.Name;
            a.ProfilId = 3;
            a.Profil = science.Profil;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(Science science,int Id)
        {
            Science science1 = _context.sciences.Find(Id);
            if (science1==null)
            {
                return NotFound();

            }

            _context.sciences.Remove(science1);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Aboutindex()
        {
            List<About> about = _context.Abouts.ToList();
            return View(about);
        }
        public IActionResult AboutCreate()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AboutCreate(About about)
        {
            _context.Abouts.Add(about);
            _context.SaveChanges();
            return RedirectToAction(nameof(AboutCreate));
        }
        public IActionResult AboutUpdate(int Id)
        {
            About about = _context.Abouts.Find(Id);
            if (about==null)
            {
                return NotFound();

            }
            return View(about);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AboutUpdate(int Id,About about)
        {
            About about1 = _context.Abouts.Find(Id);
            if (about == null)
            {
                return NotFound();

            }
            about1.Descrition = about.Descrition;
            about1.Title = about.Title;
            _context.SaveChanges();
            return RedirectToAction(nameof(Aboutindex));
        }

    }
}
