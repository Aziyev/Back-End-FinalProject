using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorldTelecomFinal.DAL;
using WorldTelecomFinal.Models;
using WorldTelecomFinal.ViewModels;

namespace WorldTelecomFinal.Areas.Manage.Controllers
{
    [Area("manage")]
    [Authorize(Roles = "SuperAdmin,Admin")]
    public class CategoryController : Controller
    {
        private readonly AppDbContext _context;

        public CategoryController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(int? status, int page = 1)
        {
            IQueryable<Category> query = _context.Categories;
            if (status != null && status > 0)
            {
                if (status == 1)
                {
                    query = query.Where(b => b.IsDeleted);
                }
                else if (status == 2)
                {
                    query = query.Where(b => !b.IsDeleted);
                }
            }

            int itemCount = int.Parse(_context.Settings.FirstOrDefault(s => s.Key == "PageItemCount").Value);
            ViewBag.Status = status;
            return View(PageNatedList<Category>.Create(query, page, itemCount));
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.MainCategories = await _context.Categories.Where(c => !c.IsDeleted && c.IsMain).ToListAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Category category)
        {
            ViewBag.MainCategories = await _context.Categories.Where(c => !c.IsDeleted && c.IsMain).ToListAsync();

            if (!ModelState.IsValid)
            {
                return View();
            }

            if (category.ParentId == null || !await _context.Categories.AnyAsync(c => !c.IsDeleted && c.IsMain && c.Id == category.ParentId))
            {
                ModelState.AddModelError("ParentId", "Choose Correct Parent!!!");
                return View();
            }

            if (await _context.Categories.AnyAsync(c => !c.IsDeleted && c.Name == category.Name.Trim().ToLower()))
            {
                ModelState.AddModelError("Name", "AlreadyExist");
            }


            category.Name = category.Name.Trim();
            category.CreatedAt = DateTime.UtcNow.AddHours(4);
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();

            return RedirectToAction("index");
        }


        [HttpGet]
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
                return BadRequest();
            Category category = await _context.Categories.FirstOrDefaultAsync(c => !c.IsDeleted && c.Id == id);
            if (category == null)
                return NotFound();

            ViewBag.MainCategories = await _context.Categories.Where(c => !c.IsDeleted && c.IsMain).ToListAsync();
            return View(category);
        }


        [HttpPost]
        public async Task<IActionResult> Update(int? id, Category category)
        {
            ViewBag.MainCategories = await _context.Categories.Where(c => !c.IsDeleted && c.IsMain).ToListAsync();

            if (!ModelState.IsValid)
            {
                return View();
            }

            if (id == null)
            {
                return BadRequest();
            }

            if (id != category.Id)
            {
                return BadRequest();
            }

            if (!category.IsMain)
            {
                if (category.ParentId == null || !await _context.Categories.AnyAsync(c => c.Id == category.ParentId && c.IsMain && !c.IsDeleted))
                {
                    ModelState.AddModelError("ParentId", "Ust Mutleq Secilmelidir");
                    return View(category);
                }
            }

            Category dbCategory = await _context.Categories.FirstOrDefaultAsync(c => !c.IsDeleted && c.Id == category.Id);

            if (dbCategory == null)
            {
                return NotFound();
            }

            if (await _context.Categories.AnyAsync(c => c.Id != category.Id && c.Name.ToLower() == category.Name.Trim().ToLower()))
            {
                ModelState.AddModelError("Name", "Already Exists");
                return View(category);
            }

            dbCategory.Name = category.Name.Trim();
            dbCategory.IsMain = category.IsMain;
            dbCategory.ParentId = category.IsMain ? null : category.ParentId;
            dbCategory.IsUpdated = true;
            dbCategory.UpdatedAt = DateTime.UtcNow.AddHours(4);
            await _context.SaveChangesAsync();

            return RedirectToAction("index");
        }



        public async Task<IActionResult> Delete(int? id, int? status, int page)
        {
            if (id == null)
            {
                return BadRequest();
            }

            Category category = await _context.Categories.FirstOrDefaultAsync(b => b.Id == id && !b.IsDeleted);

            if (category == null)
            {
                return NotFound();
            }

            if (category.IsMain)
            {
                List<Category> children = await _context.Categories.Where(c => c.ParentId == category.Id && !c.IsDeleted).ToListAsync();
                foreach (Category child in children)
                {
                    child.IsDeleted = true;
                    child.DeletedAt = DateTime.UtcNow.AddHours(4);
                }
            }

            category.IsDeleted = true;
            category.DeletedAt = DateTime.UtcNow.AddHours(4);

            await _context.SaveChangesAsync();
            IQueryable<Category> categories = _context.Categories;

            if (status != null && status > 0)
            {
                if (status == 1)
                {
                    categories = categories.Where(b => b.IsDeleted);
                }
                else if (status == 2)
                {
                    categories = categories.Where(b => !b.IsDeleted);
                }
            }

            ViewBag.Status = status;
            int itemCount = int.Parse(_context.Settings.FirstOrDefault(s => s.Key == "PageItemCount").Value);
            return PartialView("_CategoryindexPartial", PageNatedList<Category>.Create(categories, page, itemCount));
        }

        public async Task<IActionResult> Restore(int? id, int? status, int page)
        {
            if (id == null)
            {
                return BadRequest();
            }

            Category category = await _context.Categories.FirstOrDefaultAsync(b => b.Id == id && b.IsDeleted);

            if (category == null)
            {
                return NotFound();
            }

            if (!category.IsMain && await _context.Categories.AnyAsync(c => c.Id == category.ParentId && c.IsDeleted))
            {
                return BadRequest();
            }

            category.IsDeleted = false;
            category.DeletedAt = null;

            await _context.SaveChangesAsync();
            IQueryable<Category> categories = _context.Categories;

            if (status != null && status > 0)
            {
                if (status == 1)
                {
                    categories = categories.Where(b => b.IsDeleted);
                }
                else if (status == 2)
                {
                    categories = categories.Where(b => !b.IsDeleted);
                }
            }

            ViewBag.Status = status;
            int itemCount = int.Parse(_context.Settings.FirstOrDefault(s => s.Key == "PageItemCount").Value);
            return PartialView("_CategoryindexPartial", PageNatedList<Category>.Create(categories, page, itemCount));
        }
    }
}
