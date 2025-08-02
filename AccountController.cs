using Microsoft.AspNetCore.Mvc;
using Saqya_system.Models;
using Saqya_system.Data;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace Saqya_system.Controllers
{
    public class AccountController : Controller
    {
        private readonly SaqyaDbContext _context;

        public AccountController(SaqyaDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.Username == username && u.Password == password);
            if (user != null)
            {
                HttpContext.Session.SetInt32("UserId", user.UserId);
                HttpContext.Session.SetString("UserType", user.UserType);
                HttpContext.Session.SetString("FullName", user.FullName);

                if (user.UserType == "زبون")
                    return RedirectToAction("Index", "Customer");
                else if (user.UserType == "سائق")
                    return RedirectToAction("Index", "Driver");
                else if (user.UserType == "مدير")
                    return RedirectToAction("Dashboard", "Admin");

                return RedirectToAction("Index", "Home");
            }

            ViewBag.Error = "اسم المستخدم أو كلمة المرور غير صحيحة";
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User user, string ConfirmPassword)
        {
            if (!ModelState.IsValid)
                return View(user);

            if (user.Password != ConfirmPassword)
            {
                ModelState.AddModelError("ConfirmPassword", "كلمة المرور وتأكيدها غير متطابقين");
                return View(user);
            }

            var userExists = _context.Users.Any(u => u.Username == user.Username);
            if (userExists)
            {
                ModelState.AddModelError("Username", "اسم المستخدم موجود مسبقًا");
                return View(user);
            }

            _context.Users.Add(user);
            _context.SaveChanges();

            return RedirectToAction("Login");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
