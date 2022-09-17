using Microsoft.AspNetCore.Mvc;

namespace WorldTelecomFinal.Controllers
{
    public class CompaniesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
