using Microsoft.AspNetCore.Mvc;
using Saqya_system.Data;
using Saqya_system.Models;
using System.Linq;

namespace Saqya_system.Controllers
{
    public class RegionController : Controller
    {
        private readonly SaqyaDbContext _context;
        public RegionController(SaqyaDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var regions = _context.Regions.ToList();
            return View(regions);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Region region)
        {
            if (ModelState.IsValid)
            {
                _context.Regions.Add(region);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(region);
        }

        public IActionResult Edit(int id)
        {
            var region = _context.Regions.Find(id);
            if (region == null) return NotFound();
            return View(region);
        }

        [HttpPost]
        public IActionResult Edit(Region region)
        {
            if (ModelState.IsValid)
            {
                _context.Regions.Update(region);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(region);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var region = _context.Regions.Find(id);
            if (region != null)
            {
                _context.Regions.Remove(region);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
