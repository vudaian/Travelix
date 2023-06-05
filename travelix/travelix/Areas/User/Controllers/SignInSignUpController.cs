using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using travelix.Model.Entities;
using travelix.Service;

namespace travelix.Areas.User.Controllers
{
    public class SignInSignUpController : Controller
    {
        private readonly TravelixContext _context;
        public SignInSignUpController(TravelixContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            if (HttpContext.Session.GetInt32("UserId") != null)
            {
                string returnUrl = HttpContext.Session.GetString("ReturnUrl");
                return Json(returnUrl);
            }
            return View();
        }

        [HttpPost]
        public IActionResult SignIn(string email, string password)
        {
            var user = _context.Khachhangs.FirstOrDefault(u => u.Email == email && u.MatKhau == password);
            if (user != null)
            {
                // Lưu thông tin đăng nhập vào Session
                HttpContext.Session.SetInt32("UserId", user.IdKhachHang);
                return Json(new { success = true });
            }
            else
            {
                return Json(new { success = false });
            }

        }

        [HttpPost]
        public IActionResult Logout()
        {
            var session = HttpContext.Session;
            session.Remove("UserId");

            return Json(new { success = true });
        }

        public JsonResult CheckCustomerExists(string email)
        {
            var customer = _context.Khachhangs.FirstOrDefault(c => c.Email == email);
            var result = (customer != null);
            return Json(result);
        }


        public JsonResult GetMaxUserId()
        {
            var maxId = _context.Khachhangs.Max(u => u.IdKhachHang);
            var userIdMax = _context.Khachhangs.FirstOrDefault(u => u.IdKhachHang == maxId);
            return Json(userIdMax);
        }

        [HttpPost]
        public IActionResult SaveReturnUrlToSession(string url)
        {
            HttpContext.Session.SetString("ReturnUrl", url);
            return Ok();
        }
    }
}
