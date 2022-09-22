﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using WorldTelecomFinal.DAL;
using WorldTelecomFinal.Models;

namespace WorldTelecomFinal.Areas.Manage.Controllers
{
    [Area("manage")]
    public class BrandController : Controller
    {

        private readonly AppDbContext _context;

        public BrandController(AppDbContext context)
        {
            _context = context;
        }
        public  async Task<IActionResult> Index(int? status)
        {
            IQueryable<Brand> brands = _context.Brands;
            if(status != null && status > 0)
            {
                if (status == 1)
                {
                    brands = brands.Where(b => b.IsDeleted);
                }
                else if (status == 2)
                {
                    brands = brands.Where(b => !b.IsDeleted);
                }
            }

            ViewBag.Status = status;



            return View(await brands.ToListAsync());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Brand brand)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            if (await _context.Brands.AnyAsync(b => b.Name.ToLower().Trim() == brand.Name.ToLower().Trim() && !b.IsDeleted))
            {
                ModelState.AddModelError("Name", $"{brand.Name} Alreade Exsist!!!");
                return View();
            }
            
            brand.CreatedAt= DateTime.UtcNow.AddHours(+4);
            await _context.Brands.AddAsync(brand);
            await _context.SaveChangesAsync();


            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
                return BadRequest();
            
            Brand brand = await _context.Brands.FirstOrDefaultAsync(b => b.Id == id);

            if (brand == null)
                return NotFound();

            return View(brand);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Update(int? id,Brand brand)
        {
            if (id == null)
                return BadRequest();

            if (id != brand.Id)
                return BadRequest();

            Brand dbbrand = await _context.Brands.FirstOrDefaultAsync(b => b.Id == brand.Id);

            if (dbbrand == null)
                return NotFound();

            if (await _context.Brands.AnyAsync(b => b.Id != brand.Id && !b.IsDeleted && b.Name.ToLower().Trim() == brand.Name.ToLower().Trim()))
            {
                ModelState.AddModelError("Name", $"{brand.Name} Alreade Exsist!!!");
                return View();
            }


            dbbrand.Name = brand.Name;
            dbbrand.IsUpdated = true;
            dbbrand.UpdatedAt = DateTime.UtcNow.AddHours(+4);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return BadRequest();

            Brand brand = await _context.Brands.FirstOrDefaultAsync(b => b.Id == id);

            if (brand == null)
                return NotFound();

            brand.IsDeleted = true;
            brand.DeletedAt = DateTime.UtcNow.AddHours(+4);

            await _context.SaveChangesAsync();
            return PartialView("_BrandIndexPartial", await _context.Brands.ToListAsync());
        }

        public async Task<IActionResult> Restore(int? id)
        {
            if (id == null)
                return BadRequest();

            Brand brand = await _context.Brands.FirstOrDefaultAsync(b => b.Id == id);

            if (brand == null)
                return NotFound();

            brand.IsDeleted = false;
            brand.DeletedAt = null;

            await _context.SaveChangesAsync();
            return PartialView("_BrandIndexPartial", await _context.Brands.ToListAsync());
        }


    }
}
