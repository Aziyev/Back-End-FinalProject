using Microsoft.AspNetCore.Mvc;

namespace WorldTelecomFinalProj.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
