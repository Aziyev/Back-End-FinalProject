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

            if (!string.IsNullOrWhiteSpace(basket))
                basketVMs = JsonConvert.DeserializeObject<List<BasketVM>>(basket);
            else
                basketVMs = new List<BasketVM>();
            BasketVM basketVM = new BasketVM
            {
                //Mene yalniz Id ve Count lazimdir, diger parametrler asagida Db productdan gelir.
                ProductId = product.Id,
                Count = 0
            };

            basketVMs.Add(basketVM);

            basket = JsonConvert.SerializeObject(basketVMs);

            HttpContext.Response.Cookies.Append("basket", basket);

            return PartialView("_BasketPartial", _getBasketItemAsync(basketVMs));

        }

        public async Task<IActionResult> DeleteFromBasket(int? id)
        {
            if (id == null) return BadRequest();

            if (!await _context.Products.AnyAsync(p => p.Id == id)) return NotFound();

            string basket = HttpContext.Request.Cookies["basket"];

            if (string.IsNullOrWhiteSpace(basket)) return BadRequest();

            List<BasketVM> basketVMs = JsonConvert.DeserializeObject<List<BasketVM>>(basket);   

            BasketVM basketVM = basketVMs.Find(b=>b.ProductId == id);

            if (basketVM == null) return NotFound();

            basketVMs.Remove(basketVM);

            basket = JsonConvert.SerializeObject(basketVMs);

            HttpContext.Response.Cookies.Append("basket", basket);

           
            return PartialView("_BasketPartial", _getBasketItemAsync(basketVMs));
        }




        //Databasede melumat deyisende melumat yenilensin diye isdifade olunur.
        //Private olmaq sebebi colden sorgu gelmeyn qarsisin almaqdi !
        private async Task<List<BasketVM>> _getBasketItemAsync(List<BasketVM> basketVMs)
        {
            foreach (BasketVM item in basketVMs)
            {
                Product dbProduct = await _context.Products.FirstOrDefaultAsync(p => p.Id == item.ProductId);

                item.Name = dbProduct.Name;
                item.Price = dbProduct.DiscoutnPrice > 0 ? dbProduct.DiscoutnPrice : dbProduct.Price;
                item.Image = dbProduct.MainImage;
            }

            return basketVMs;
        }
    }
}
