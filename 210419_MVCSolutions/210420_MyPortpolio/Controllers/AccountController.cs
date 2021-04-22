using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using _210420_MyPortpolio.Data;
using _210420_MyPortpolio.Models;


namespace _210420_MyPortpolio.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            var account = new Account();
            return View(account);
        }

        [HttpPost]
        public async Task<IActionResult> Login([Bind("Email, Password")] Account account)
        {
            if(ModelState.IsValid)  // 제대로 입력됬다면
            {
                var result = CheckAccount(account.Email, account.Password);  // 이메일과 패스워드를 체크

                if(result == null) // 계정이 없는 경우 화면을 Home/index로 이동
                {
                    ViewBag.Message = "해당 계정이 없습니다";
                    return View("Login");
                }
                else  // 로그인 됬을때
                {
                    HttpContext.Session.SetString("UserEmail", result.Email);
                    return RedirectToAction("Index", "Home");
                }
            }
            return View("Login");  // null에서 변경했음
        }

        private Account CheckAccount(string email, string password)
        {
            return _context.Account.SingleOrDefault(a => a.Email.Equals(email) && a.Password.Equals(password));
        }



        public IActionResult LogOut()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}
