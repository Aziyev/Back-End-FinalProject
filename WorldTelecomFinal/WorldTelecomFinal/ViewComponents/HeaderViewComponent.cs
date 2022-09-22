using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using WorldTelecomFinal.DAL;
using WorldTelecomFinal.Models;
using WorldTelecomFinal.ViewModels.BasketViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using WorldTelecomFinal.ViewModels.HeaderViewModels;

namespace WorldTelecomFinal.ViewComponents
{
    public class HeaderViewComponent : ViewComponent
    {
        private readonly AppDbContext _context;

        public HeaderViewComponent(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(IDictionary<string, string> settings)
        {
            List<BasketVM> basketVMs = null;

            string basket = HttpContext.Request.Cookies["basket"];

            if (!string.IsNullOrWhiteSpace(basket))
            {
                basketVMs = JsonConvert.DeserializeObject<List<BasketVM>>(basket);

                foreach (BasketVM basketVM in basketVMs)
                {
                    Product product = await _context.Products.FirstOrDefaultAsync(p => p.Id == basketVM.ProductId);

                    basketVM.Image = product.MainImage;
                    basketVM.Name = product.Name;
                    basketVM.Price = product.DiscoutnPrice > 0 ? product.DiscoutnPrice : product.Price;
                }
            }
            else
            {
                basketVMs = new List<BasketVM>();
            }

            HeaderViewModel headerViewModel = new HeaderViewModel
            {
                Settings = settings,
                BasketVMs = basketVMs
            };
            return View(await Task.FromResult(headerViewModel));
        }
    }
}