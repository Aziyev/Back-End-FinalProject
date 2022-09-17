using Microsoft.AspNetCore.Mvc;

namespace WorldTelecomFinal.Controllers
{
    public class MarketsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
