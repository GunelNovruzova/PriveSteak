using Final.DAL;
using Final.Extensions;
using Final.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class TableCategoryController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        public TableCategoryController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IActionResult> Index(bool? status, int page = 1)
        {
            ViewBag.Status = status;


            IQueryable<TableCategory> tableCategories = _context.TableCategories
                .OrderByDescending(t => t.CreatedAt);
                if (status != null)
                tableCategories = tableCategories.Where(c => c.IsDeleted == status);
            ViewBag.PageIndex = page;
            ViewBag.PageCount = Math.Ceiling((double)tableCategories.Count() / 5);

            return View(await tableCategories.Skip((page - 1) * 5).Take(5).ToListAsync());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TableCategory tablecategory)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            //if (tablecategory.Title.CheckString())
            //{
            //    ModelState.AddModelError("Name", "Name may can contain only letters");
            //    return View();
            //}

            if (await _context.TableCategories.AnyAsync(t => t.Title.ToLower() == tablecategory.Title.ToLower()))
            {
                ModelState.AddModelError("Name", "This Name already exists");
                return View();
            }

            tablecategory.CreatedAt = DateTime.UtcNow.AddHours(4);

            await _context.TableCategories.AddAsync(tablecategory);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Update(int? id, bool? status, int page = 1)
        {
            if (id == null) return BadRequest();

            TableCategory tableCategory = await _context.TableCategories.FirstOrDefaultAsync(t => t.Id == id);

            if (tableCategory == null) return NotFound();

            return View(tableCategory);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, TableCategory tableCategory, bool? status, int page = 1)
        {
            if (!ModelState.IsValid) return View(tableCategory);

            if (id == null) return BadRequest();

            if (id != tableCategory.Id) return BadRequest();

            TableCategory dbTablecategory = await _context.TableCategories.FirstOrDefaultAsync(t => t.Id == id);

            if (dbTablecategory == null) return NotFound();

            if (string.IsNullOrWhiteSpace(tableCategory.Title))
            {
                ModelState.AddModelError("Name", "There should be no gaps");
                return View(tableCategory);
            }

            if (tableCategory.Title.CheckString())
            {
                ModelState.AddModelError("Name", "Name may can contain only letters");
                return View(tableCategory);
            }

            if (await _context.TableCategories.AnyAsync(t => t.Id != tableCategory.Id && t.Title.ToLower() == tableCategory.Title.ToLower()))
            {
                ModelState.AddModelError("Name", "This Name already exists");
                return View(tableCategory);
            }

            dbTablecategory.Title = tableCategory.Title;
            dbTablecategory.UpdatedAt = DateTime.UtcNow.AddHours(4);

            await _context.SaveChangesAsync();

            return RedirectToAction("Index", new { status = status, page = page });
        }
        public async Task<IActionResult> Delete(int? id, bool? status, int page = 1)
        {
            if (id == null) return BadRequest();

            TableCategory dbTableCategory = await _context.TableCategories.FirstOrDefaultAsync(t => t.Id == id);

            if (dbTableCategory == null) return NotFound();

            dbTableCategory.IsDeleted = true;
            dbTableCategory.DeletedAt = DateTime.UtcNow.AddHours(4);

            await _context.SaveChangesAsync();

            ViewBag.Status = status;

            IEnumerable<TableCategory> tableCategories = await _context.TableCategories
                .Where(t => status != null ? t.IsDeleted == status : true)
                .OrderByDescending(t => t.CreatedAt)
                .ToListAsync();

            ViewBag.PageIndex = page;
            ViewBag.PageCount = Math.Ceiling((double)tableCategories.Count() / 5);



            return PartialView("_TableCategoryPartial", tableCategories.Skip((page - 1) * 5).Take(5));
        }
        public async Task<IActionResult> Restore(int? id, bool? status, int page = 1)
        {
            if (id == null) return BadRequest();

            TableCategory dbtableCategory = await _context.TableCategories.FirstOrDefaultAsync(t => t.Id == id);

            if (dbtableCategory == null) return NotFound();

            dbtableCategory.IsDeleted = false;
            dbtableCategory.DeletedAt = null;

            await _context.SaveChangesAsync();

            ViewBag.Status = status;

            IEnumerable<TableCategory> tableCategories = await _context.TableCategories
                .Where(t => status != null ? t.IsDeleted == status : true)
                .OrderByDescending(t => t.CreatedAt)
                .ToListAsync();

            ViewBag.PageIndex = page;
            ViewBag.PageCount = Math.Ceiling((double)tableCategories.Count() / 5);



            return PartialView("_TableCategoryPartial", tableCategories.Skip((page - 1) * 5).Take(5));
        }

    }
}
