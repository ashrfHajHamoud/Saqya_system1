using Microsoft.AspNetCore.Mvc;
using Saqya_system.Data;
using Saqya_system.Models;
using System.Linq;

namespace Saqya_system.Controllers
{
    public class CustomerController : Controller
    {
        private readonly SaqyaDbContext _context;

        public CustomerController(SaqyaDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var customers = _context.Users
                .Where(u => u.UserType == "زبون")
                .ToList();

            return View(customers);
        }

        [HttpGet]
        public IActionResult CreateOrder()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateOrder(CustomerOrder order)
        {
            if (ModelState.IsValid)
            {
                _context.CustomerOrders.Add(order);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(order);
        }
    }
}
