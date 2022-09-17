using Microsoft.AspNetCore.Mvc;

namespace WorldTelecomFinal.Controllers
{
    public class VacansiesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
