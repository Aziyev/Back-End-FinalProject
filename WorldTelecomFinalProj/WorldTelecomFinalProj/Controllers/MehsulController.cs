using Microsoft.AspNetCore.Mvc;
using WorldTelecomFinalProj.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WorldTelecomFinalProj.Controllers
{
    public class MehsulController : Controller
    {
        private readonly AppDbContext _context;
        public MehsulController(AppDbContext context) 
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Products.ToListAsync());
        }
    }
}
