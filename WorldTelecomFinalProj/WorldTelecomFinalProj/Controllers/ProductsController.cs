using Microsoft.AspNetCore.Mvc;

namespace WorldTelecomFinalProj.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
