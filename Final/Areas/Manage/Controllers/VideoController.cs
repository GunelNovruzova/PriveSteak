using Final.DAL;
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
    public class VideoController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        public VideoController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Videos.ToListAsync());
        }
        public async Task<IActionResult> Detail(int? id)
        {
            return View(await _context.Videos.FirstOrDefaultAsync());
        }
        public async Task<IActionResult> Update(int? id)
        {
            return View(await _context.Videos.FirstOrDefaultAsync());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Video video, bool? status, int page = 1)
        {
            if (id == null) return BadRequest(); 

            Video dbVideo = await _context.Videos.FirstOrDefaultAsync(s => s.Id == id);
            if (dbVideo == null) return NotFound();

            if (!ModelState.IsValid) return View();


            dbVideo.VideoLink = video.VideoLink;
            dbVideo.UpdatedAt = DateTime.UtcNow.AddHours(4);
            await _context.SaveChangesAsync();
            return RedirectToAction("index", new { status, page });
        }
    }
}
