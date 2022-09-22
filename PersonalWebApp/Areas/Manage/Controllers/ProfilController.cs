using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonalWebApp.Dal;
using PersonalWebApp.Models;
using PersonalWebApp.Utilites;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalWebApp.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class ProfilController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public ProfilController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;

        }
        public IActionResult Index()
        {
            List<Profil> profil = _context.profils.ToList();

            return View(profil);
        }  
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task< IActionResult> Create(Profil profil)
        {
            if (!ModelState.IsValid)
            {
                return View();

            }
            if (!(profil.Photo.CheckSize(5)))
            {
                ModelState.AddModelError("Photo", "5mb limitini kecibsiz");
                return View();

            }
            if (!(profil.Photo.CheckType("image/")))
            {
                ModelState.AddModelError("Photo", "image formatinda bir seyler at");
                return View();

            }
            profil.ImgUrl = await profil.Photo.SaveFileAsync(Path.Combine(_env.WebRootPath,"Musi","Image"));
            _context.profils.Add(profil);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
        public IActionResult Update(int Id)
        {
            Profil profil=_context.profils.Find(Id);
            if (profil == null) return NotFound();
            return View(profil);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task< IActionResult> Update(Profil profil,int Id)
        {
            Profil profil1 = _context.profils.Find(Id);
            if (profil == null) return NotFound();

            profil1.Email = profil.Email;
            profil1.Degree=profil.Degree;
            profil1.Phone = profil.Phone;
            profil1.FullName = profil1.FullName;
            if (!ModelState.IsValid)
            {
                return View();

            }
            if (!(profil.Photo.CheckSize(5)))
            {
                ModelState.AddModelError("Photo", "5mb limitini kecibsiz");
                return View();

            }
            if (!(profil.Photo.CheckType("image/")))
            {
                ModelState.AddModelError("Photo", "image formatinda bir seyler at");
                return View();

            }
            profil1.ImgUrl = await profil.Photo.SaveFileAsync(Path.Combine(_env.WebRootPath, "Musi", "Image"));
            _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
