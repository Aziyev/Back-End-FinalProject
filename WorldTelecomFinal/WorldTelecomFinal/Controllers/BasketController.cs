using Microsoft.AspNetCore.Mvc;
using WorldTelecomFinal.DAL;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorldTelecomFinal.Models;
using WorldTelecomFinal.ViewModels.BasketViewModels;

namespace WorldTelecomFinal.Controllers
{
    public class BasketController : Controller
    {
        private readonly AppDbContext _context;
        public BasketController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> AddToBasket(int? id)
        {
            if (id == null) return BadRequest();
            Product product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (product == null) return NotFound();

            string basket = HttpContext.Request.Cookies["basket"];

            List<BasketVM> basketVMs = null;

            if (basket != null)
            {
                basketVMs = JsonConvert.DeserializeObject<List<BasketVM>>(basket);
            }
            else
            {
                basketVMs = new List<BasketVM>();
            }
            BasketVM basketVM = new BasketVM
            {
                ProductId = product.Id,
                Count = 0,
                Image = product.MainImage,
                Name = product.Name,
                Price = product.DiscoutnPrice > 0 ? product.DiscoutnPrice : product.Price,
            };

            basketVMs.Add(basketVM);

            basket = JsonConvert.SerializeObject(basket);

            HttpContext.Response.Cookies.Append("basket", basket);

            return PartialView("_BasketPartial", basketVM);




        }
    }
}
