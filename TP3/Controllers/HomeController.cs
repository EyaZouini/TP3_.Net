using Microsoft.AspNetCore.Mvc;

namespace TP3.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("Index", "Concerts");
        }

    }
}
