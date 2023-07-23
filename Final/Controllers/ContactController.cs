using Final.DAL;
using Final.Models;
using Final.ViewModels.Contact;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final.Controllers
{
    public class ContactController : Controller
    {
        private readonly AppDbContext _context;

        private readonly UserManager<AppUser> _userManager;

        public ContactController(AppDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            Setting setting = _context.Settings.FirstOrDefault();
            Contact contact = _context.Contacts.FirstOrDefault();
            ContactVM contactVM = new ContactVM()
            {
                Setting = setting
            };
            return View(contactVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ContactMessage(Contact contact)
        {
            
            //if (!User.Identity.IsAuthenticated)
            //{
            //    return RedirectToAction("login", "account");
            //}


            AppUser appUser = await _userManager.Users.FirstOrDefaultAsync(u => u.UserName == User.Identity.Name && !u.IsAdmin);


            if (string.IsNullOrWhiteSpace(contact.Name))
            {
                ModelState.AddModelError("Name", "There should be no gaps");
                return View();
            }

            if (string.IsNullOrWhiteSpace(contact.Message))
            {
                ModelState.AddModelError("Message", "There should be no gaps");
                return View();
            }
            if (string.IsNullOrWhiteSpace(contact.Email))
            {
                ModelState.AddModelError("Email", "There should be no gaps");
                return View();
            }
            //contact.MainEmail = appUser.Email;

            contact.CreatedAt = DateTime.UtcNow.AddHours(4);

            await _context.Contacts.AddAsync(contact);
            await _context.SaveChangesAsync();

            return RedirectToAction("index");
        }
    }
}
