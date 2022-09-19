using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using WorldTelecomFinal.DAL;

namespace WorldTelecomFinal.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {

            // Session barede Numune -1
            //HttpContext.Session.SetString("p129", "p129 Hello World!");

            //Cookie Barede Numune -1
            //HttpContext.Response.Cookies.Append("p129", "p129 Hello World Cookie!");

            return View(await _context.Products.ToListAsync());
        }



        //Session Barede Numune -2
        //public IActionResult GetSession()
        //{
        //    string session = HttpContext.Session.GetString("p129");

        //    return Content(session);
        //}


        //Cookie Barede Numune -2
        //public IActionResult GetCookie()
        //{
        //    string session = HttpContext.Request.Cookies["p129"];

        //    return Content(session);
        //}
    }
}
