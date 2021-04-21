using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using _210420_MyPortpolio.Data;
using _210420_MyPortpolio.Models;

namespace _210420_MyPortpolio.Controllers
{
    public class ContactsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ContactsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        // GET: Contacts
        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index([Bind("Id, Name, Email, Contents")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    contact.RegDate = DateTime.Now;
                    _context.Add(contact);
                    await _context.SaveChangesAsync();

                    // Back단에있는 문자열을 View 화면쪽으로 옮기기위해 쓰는 클래스 중 하나
                    ViewBag.Message = "감사합니다. 연락드리겠습니다.";
                }
                catch (Exception ex)
                {
                    ModelState.Clear();
                    ViewBag.Message = $"예외가 발생했습니다. {ex.Message}";
                }
                // return RedirectToAction(nameof(Index));
            }
            return View();
        }
    }
}
