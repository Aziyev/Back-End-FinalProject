using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorldTelecomFinal.DAL;
using WorldTelecomFinal.Models;
using WorldTelecomFinal.ViewModels.BasketViewModels;
using WorldTelecomFinal.ViewModels.HomeViewModels;


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
            List<Product> products = await _context.Products.ToListAsync();

            HomeViewModel homeViewModel = new HomeViewModel
            {
                Products = await _context.Products.ToListAsync(),
                Sliders = await _context.Sliders.ToListAsync(),
                BestSeller = products.Where(p => p.BestSeller).ToList(),
                NewArrivel = products.Where(p => p.IsNewArrivel).ToList()
            };

            return View(homeViewModel);
        }

            // Session barede Numune -1
            //HttpContext.Session.SetString("p129", "p129 Hello World!");

            //Cookie Barede Numune -1
            //HttpContext.Response.Cookies.Append("p129", "p129 Hello World Cookie!");
            //string basket = HttpContext.Request.Cookies["basket"];
        
            //List<BasketVM> basketVMs = null;

            //if (basket != null)
            //{
            //    basketVMs = JsonConvert.DeserializeObject<List<BasketVM>>(basket);
            //}
            //else
            //{
            //    basketVMs = new List<BasketVM>();
            //}

            //ViewBag.Basket = basketVMs;

        //    return View(await _context.Products.ToListAsync());
        //}

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
