using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WorldTelecomFinal.DAL;
using WorldTelecomFinal.Models;

namespace WorldTelecomFinal.ViewComponents
{
    public class SliderViewComponent : ViewComponent
    {
        private readonly AppDbContext _context;

        public SliderViewComponent(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync(List<Slider> sliders)
        {
            return View(await Task.FromResult(sliders));
        }
    }
}
