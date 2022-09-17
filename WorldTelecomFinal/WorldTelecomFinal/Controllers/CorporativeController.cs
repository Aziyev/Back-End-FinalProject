using Microsoft.AspNetCore.Mvc;

namespace WorldTelecomFinal.Controllers
{
    public class CorporativeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
