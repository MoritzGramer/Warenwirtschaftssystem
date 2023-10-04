using Microsoft.AspNetCore.Mvc;

namespace Warenwirtschaftssystem.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
