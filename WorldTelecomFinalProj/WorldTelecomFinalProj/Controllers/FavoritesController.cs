using Microsoft.AspNetCore.Mvc;

namespace WorldTelecomFinalProj.Controllers
{
    public class FavoritesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
