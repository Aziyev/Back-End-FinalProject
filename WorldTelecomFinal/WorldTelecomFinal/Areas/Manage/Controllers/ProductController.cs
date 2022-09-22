﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using WorldTelecomFinal.DAL;

namespace WorldTelecomFinal.Areas.Manage.Controllers
{
    [Area("manage")]
    public class ProductController : Controller
    {

        private readonly AppDbContext _context;

        public ProductController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Products.ToListAsync());
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ProductCreate(string name, string surname, int age, string email)
        {
            return Content($"{name} {surname} {age} {email}");
        }

    }
}
