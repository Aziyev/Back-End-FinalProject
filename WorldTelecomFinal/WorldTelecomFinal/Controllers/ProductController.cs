using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorldTelecomFinal.DAL;
using WorldTelecomFinal.Models;
using WorldTelecomFinal.ViewModels.BasketViewModels;

namespace WorldTelecomFinal.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;
        public ProductController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(int? id)
        {
            if (id == null) return BadRequest();

            Product product = await _context.Products
                .Include(p=>p.ProductsImages)
                .Include(p=>p.Brand).ThenInclude(p=>p.Products)
                .Include(p=>p.ProductsTags).ThenInclude(pt=>pt.Tag)
                .FirstOrDefaultAsync(p=>p.Id == id);

            if (product == null) return NotFound(); 

            return View(product);
        }

        //----------Search ucun Partial View-----------------

        public async Task<IActionResult> Search(string search)
        {
            List<Product> products = await _context.Products
                .Where(p => p.Name.ToLower().Contains(search.ToLower()) || 
                p.Brand.Name.ToLower().Contains(search.ToLower()) || 
                p.ProductsTags.Any(pt=>pt.Tag.Name.ToLower().Contains(search.ToLower()))).ToListAsync();

            return PartialView("_SearchPartial", products);
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
