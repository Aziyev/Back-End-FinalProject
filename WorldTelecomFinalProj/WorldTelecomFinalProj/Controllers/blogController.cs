using Microsoft.AspNetCore.Mvc;

namespace WorldTelecomFinalProj.Controllers
{
    public class blogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
