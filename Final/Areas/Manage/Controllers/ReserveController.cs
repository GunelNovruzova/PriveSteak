using Final.DAL;
using Final.Extensions;
using Final.Helpers;
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
    public class ReserveController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        public ReserveController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IActionResult> Index(bool? status, int page = 1)
        {
            ViewBag.Status = true;

            IEnumerable<Reserve> reserves = await _context.Reserves
                .Where(t => status != null ? t.IsDeleted == status : true)
                .OrderByDescending(t => t.CreatedAt)

                .ToListAsync();

            ViewBag.PageIndex = page;
            ViewBag.PageCount = Math.Ceiling((double)reserves.Count() / 5);

            return View(reserves.Skip((page - 1) * 5).Take(5));

        }
        public IActionResult Detail(int? id)
        {
            if (id == null) return BadRequest();

            Reserve reserve = _context.Reserves
               
                .FirstOrDefault(p => p.Id == id);

            if (reserve == null) return NotFound();

            return View(reserve);
        }
        public async Task<IActionResult> Create()
        {
            ViewBag.Tablecategories = await _context.TableCategories.ToListAsync();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Reserve reserve)
        {
            ViewBag.Tablecategories = await _context.TableCategories.ToListAsync();
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (reserve.ImageFile != null)
            {
                if (!reserve.ImageFile.CheckFileContentType("image/jpeg"))
                {
                    ModelState.AddModelError("ImageFile", "The selected image type doesn't match");
                    return View();
                }

                if (!reserve.ImageFile.CheckFileSize(100000))
                {
                    ModelState.AddModelError("ImageFile", "The Size of the Selected Image Can Be Maximum 10000 Kb");
                    return View();
                }

                reserve.Image = reserve.ImageFile.CreateFile(_env, "assets", "img", "about");
            }
            else
            {
                ModelState.AddModelError("ImageFile", "Image must be selected");
                return View();
            }



            reserve.CreatedAt = DateTime.UtcNow.AddHours(4);
           
            await _context.Reserves.AddAsync(reserve);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int? id, bool? status, int page = 1)
        {
            if (id == null) return BadRequest();

            Reserve reserve = await _context.Reserves.FirstOrDefaultAsync(t => t.Id == id);

            if (reserve == null) return NotFound();

            return View(reserve);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Reserve reserve, bool? status, int page = 1)
        {
            if (!ModelState.IsValid) return View(reserve);

            if (id == null) return BadRequest();

            if (id != reserve.Id) return BadRequest();

            Reserve dbReserve = await _context.Reserves.FirstOrDefaultAsync(t => t.Id == id);

            if (dbReserve == null) return NotFound();
            if (reserve.ImageFile != null)
            {
                if (!reserve.ImageFile.CheckFileContentType("image/jpeg"))
                {
                    ModelState.AddModelError("ImageFile", "The selected image type doesn't match");
                    return View();
                }

                if (!reserve.ImageFile.CheckFileSize(100000))
                {
                    ModelState.AddModelError("ImageFile", "The Size of the Selected Image Can Be Maximum 10000 Kb");
                    return View();
                }

                Helper.DeleteFile(_env, dbReserve.Image, "assets", "img", "about");
                dbReserve.Image = reserve.ImageFile.CreateFile(_env, "assets", "img", "about");

            }
            dbReserve.UpdatedAt = DateTime.UtcNow.AddHours(4);

            await _context.SaveChangesAsync();

            return RedirectToAction("Index", new { status = status, page = page });
        }

        public async Task<IActionResult> Delete(int? id, bool? status, int page = 1)
        {
            if (id == null) return BadRequest();

            Reserve dbreserve = await _context.Reserves.FirstOrDefaultAsync(t => t.Id == id);

            if (dbreserve == null) return NotFound();

            dbreserve.IsDeleted = true;
            dbreserve.DeletedAt = DateTime.UtcNow.AddHours(4);

            await _context.SaveChangesAsync();

            ViewBag.Status = status;

            IEnumerable<Reserve> reserves = await _context.Reserves
                .Where(t => status != null ? t.IsDeleted == status : true)
                .OrderByDescending(t => t.CreatedAt)
                .ToListAsync();

            ViewBag.PageIndex = page;
            ViewBag.PageCount = Math.Ceiling((double)reserves.Count() / 5);



            return PartialView("_ReserveIndexPartial", reserves.Skip((page - 1) * 5).Take(5));
        }
        public async Task<IActionResult> Restore(int? id, bool? status, int page = 1)
        {
            if (id == null) return BadRequest();

            Reserve dbreserve = await _context.Reserves.FirstOrDefaultAsync(t => t.Id == id);

            if (dbreserve == null) return NotFound();

            dbreserve.IsDeleted = false;
            dbreserve.DeletedAt = null;

            await _context.SaveChangesAsync();

            ViewBag.Status = status;

            IEnumerable<Reserve> reserves = await _context.Reserves
                .Where(t => status != null ? t.IsDeleted == status : true)
                .OrderByDescending(t => t.CreatedAt)
                .ToListAsync();

            ViewBag.PageIndex = page;
            ViewBag.PageCount = Math.Ceiling((double)reserves.Count() / 5);



            return PartialView("_ReserveIndexPartial", reserves.Skip((page - 1) * 5).Take(5));
        }
    }
}
