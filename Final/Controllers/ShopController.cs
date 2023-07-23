using Final.DAL;
using Final.Models;
using Final.ViewModels.Products;
using Final.ViewModels.Shop;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final.Controllers
{
    public class ShopController : Controller
    {
        private readonly AppDbContext _context;
        public ShopController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(string sortby, int? cid, int page = 1)
        {
            ViewBag.cid = cid;

            int perPage = 6;

            IQueryable<Product> products = _context.Products;
            if (cid != null) products = products.Where(p => p.CategoryId == cid);

            switch (sortby)
            {
                case "AZ":
                    products = products.Where(p => !p.IsDeleted).OrderBy(p => p.Name);
                    break;
                case "ZA":
                    products = products.Where(p => !p.IsDeleted).OrderByDescending(p => p.Name);
                    break;
                case "LH":
                    products = products.Where(p => !p.IsDeleted).OrderBy(p => p.Price);
                    break;
                case "HL":
                    products = products.Where(p => !p.IsDeleted).OrderByDescending(p => p.Price);
                    break;
                default:
                    products = products.Where(p => !p.IsDeleted).OrderBy(p => p.Name);
                    break;
            }

            ViewBag.PageIndex = page;
            ViewBag.PageCount = Math.Ceiling((double)products.Where(b => !b.IsDeleted).Count() / perPage);

            Setting setting = _context.Settings.FirstOrDefault();
            ShopVM shopVM = new ShopVM
            {
                Products = products.OrderBy(p => p.Id).Skip((page - 1) * perPage).Take(perPage).ToList(),
                Categories = await _context.Categories.Include(c => c.Products).Where(c => !c.IsDeleted).ToListAsync(),
                Setting = setting
            };

            return View(shopVM);
        }

        public async Task<IActionResult> Detail(int? pid)
        {
            ViewBag.Categories = await _context.Categories.ToListAsync();


            if (pid == null) return BadRequest();

            Product product = await _context.Products

                .FirstOrDefaultAsync(p => p.Id == (int)pid);

            if (product == null) return NotFound();
            ProductVM productVM = new ProductVM()
            {
                Product = product,
                Products = await _context.Products
                .Where(p => p.CategoryId == product.CategoryId)
                .Take(3)
                .OrderByDescending(p => p.CreatedAt)
                .ToListAsync(),

            };
            return View(productVM);
        }
        public async Task<IActionResult> Search(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                return RedirectToAction("Index", "Shop");
            }
            List<Product> products = await _context.Products.Where(p => p.Name.ToLower().Contains(query.ToLower())).ToListAsync();
            return View(products);
        }
        public async Task<IActionResult> SearchPartial(string query)
        {
            List<Product> products = await _context.Products.Where(p => p.Name.ToLower().Contains(query.ToLower())).ToListAsync();
            return PartialView("_ProductSearchPartial", products);
        }
        public async Task<IActionResult> CategoryFilter(int? id)
        {
            List<Product> product = await _context.Products.Where(p => p.CategoryId == id && !p.IsDeleted).Take(4).ToListAsync();

            return PartialView("_ShopCategoryPartial", product);
        }
    }
}
