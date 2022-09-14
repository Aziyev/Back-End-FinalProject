using Microsoft.AspNetCore.Mvc;

namespace WorldTelecomFinalProj.Controllers
{
    public class CompaniesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
