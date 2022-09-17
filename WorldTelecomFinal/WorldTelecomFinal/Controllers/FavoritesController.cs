using Microsoft.AspNetCore.Mvc;

namespace WorldTelecomFinal.Controllers
{
    public class FavoritesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
