using Microsoft.AspNetCore.Mvc;

namespace WorldTelecomFinalProj.Controllers
{
    public class BasketController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
