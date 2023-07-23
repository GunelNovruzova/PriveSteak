using Final.DAL;
using Final.Models;
using Final.ViewModels.About;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final.Controllers
{
    public class AboutController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        public AboutController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            Setting setting = _context.Settings.FirstOrDefault();
            AboutVM aboutVM = new AboutVM
            {
                Products = await _context.Products.Where(p => !p.IsDeleted).ToListAsync(),
                AboutIntros = await _context.AboutIntros.Where(p => !p.IsDeleted).ToListAsync(),
                Videos = await _context.Videos.Where(p => !p.IsDeleted).ToListAsync(),
                Setting = setting


            };
            ViewBag.Category = await _context.Categories.Where(p => p.Image != null).ToListAsync();
            return View(aboutVM);
        }
        public async Task<IActionResult> DetailModal(int? id)
        {
            if (id == null) return BadRequest();
            Product product = await _context.Products
            .FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted);
            if (product == null) return NotFound();

            return PartialView("_ProductModalPartial", product);
        }
    }
}
 