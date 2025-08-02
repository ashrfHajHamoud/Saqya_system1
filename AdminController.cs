using Microsoft.AspNetCore.Mvc;
using Saqya_system.Data;
using Saqya_system.Models;
using System.Linq;

namespace Saqya_system.Controllers
{
    public class AdminController : Controller
    {
        private readonly SaqyaDbContext _context;

        public AdminController(SaqyaDbContext context)
        {
            _context = context;
        }

        public IActionResult Dashboard()
        {
            var dashboardData = new AdminDashboardViewModel
            {
                TotalOrders = _context.CustomerOrders.Count(),

                TopRegion = _context.CustomerOrders
                    .GroupBy(o => o.Region)
                    .OrderByDescending(g => g.Count())
                    .Select(g => g.Key)
                    .FirstOrDefault() ?? "لا توجد بيانات",

                AverageDeliveryTime = "1 ساعة 45 دقيقة", // يمكنك تحسين الحساب لاحقًا

                DriverRatings = "4.5 / 5", // بيانات ثابتة كمثال

                Users = _context.Users.ToList(),

                Regions = _context.Regions.ToList()
            };

            return View(dashboardData);
        }

        // إدارة المستخدمين
        public IActionResult ManageUsers()
        {
            var users = _context.Users.ToList();
            return View(users);
        }

        [HttpPost]
        public IActionResult DeleteUser(int id)
        {
            var user = _context.Users.Find(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
            return RedirectToAction("Dashboard");
        }

        // إدارة المناطق
        public IActionResult Regions()
        {
            var regions = _context.Regions.ToList();
            return View(regions);
        }

        // GET: عرض نموذج إضافة منطقة
        [HttpGet]
        public IActionResult CreateRegion()
        {
            return View();
        }

        // POST: استقبال بيانات المنطقة وحفظها في قاعدة البيانات
        [HttpPost]
        public IActionResult CreateRegion(Region region)
        {
            if (ModelState.IsValid)
            {
                _context.Regions.Add(region);
                _context.SaveChanges();

                return RedirectToAction("Dashboard"); // أو أي صفحة تريد
            }

            return View(region); // عند وجود خطأ عرض النموذج مع الرسائل
        }


        [HttpGet]
        public IActionResult EditRegion(int id)
        {
            var region = _context.Regions.Find(id);
            if (region == null)
                return NotFound();

            return View(region);
        }

        [HttpPost]
        public IActionResult EditRegion(Region region)
        {
            if (ModelState.IsValid)
            {
                _context.Regions.Update(region);
                _context.SaveChanges();
                return RedirectToAction("Dashboard");
            }
            return View(region);
        }

        [HttpPost]
        public IActionResult DeleteRegion(int id)
        {
            var region = _context.Regions.Find(id);
            if (region != null)
            {
                _context.Regions.Remove(region);
                _context.SaveChanges();
            }
            return RedirectToAction("Dashboard");
        }
    }
}
