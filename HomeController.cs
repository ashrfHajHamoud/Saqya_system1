using Microsoft.AspNetCore.Mvc;

namespace Saqya_system.Controllers
{
    public class HomeController : Controller
    {
        // ������ ��������
        public IActionResult Index()
        {
            return View();
        }
    }
}
