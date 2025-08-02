using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Saqya_system.Data;
using Saqya_system.Models;
using System.Collections.Generic;
using System.Linq;

namespace Saqya_system.Controllers
{
    public class DriverController : Controller
    {
        private readonly SaqyaDbContext _context;

        public DriverController(SaqyaDbContext context)
        {
            _context = context;
        }

        // تهيئة قوائم الاختيار في الـ ViewBag
        private void PopulateDropdowns()
        {
            ViewBag.TankSizeList = new List<SelectListItem>
            {
                new SelectListItem { Value = "خزان كامل", Text = "خزان كامل" },
                new SelectListItem { Value = "جزء من خزان", Text = "جزء من خزان" }
            };

            ViewBag.TankStatusList = new List<SelectListItem>
            {
                new SelectListItem { Value = "مشغول", Text = "مشغول" },
                new SelectListItem { Value = "غير مشغول", Text = "غير مشغول" }
            };
        }

        // عرض قائمة السائقين
        public IActionResult Index()
        {
            var drivers = _context.Drivers.ToList();
            return View(drivers);
        }

        // صفحة إضافة سائق (GET)
        [HttpGet]
        public IActionResult Create()
        {
            PopulateDropdowns();
            return View(new Driver());
        }

        // معالجة إضافة سائق (POST)
        [HttpPost]
        public IActionResult Create(Driver driver)
        {
            if (ModelState.IsValid)
            {
                _context.Drivers.Add(driver);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            PopulateDropdowns();
            return View(driver);
        }

        // صفحة تعديل سائق (GET)
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var driver = _context.Drivers.Find(id);
            if (driver == null)
                return NotFound();

            PopulateDropdowns();
            return View(driver);
        }

        // معالجة تعديل سائق (POST)
        [HttpPost]
        public IActionResult Edit(Driver driver)
        {
            if (ModelState.IsValid)
            {
                _context.Drivers.Update(driver);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            PopulateDropdowns();
            return View(driver);
        }

        // حذف سائق (POST)
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var driver = _context.Drivers.Find(id);
            if (driver != null)
            {
                _context.Drivers.Remove(driver);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
