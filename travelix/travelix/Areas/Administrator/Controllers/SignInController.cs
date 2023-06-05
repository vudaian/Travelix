using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using travelix.Model.Entities;

namespace travelix.Areas.Administrator.Controllers
{
    public class SignInController : Controller
    {
        private readonly TravelixContext _context;
        public SignInController(TravelixContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            if (HttpContext.Session.GetInt32("AdminId") != null)
            {
                return Redirect("/Administrator/Dashboard/Index");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Index(string username, string password)
        {
            var user = _context.Taikhoanquanlies.FirstOrDefault(u => u.TaiKhoan == username && u.MatKhau == password);
            if (user != null)
            {
                // Lưu thông tin đăng nhập vào Session
                HttpContext.Session.SetInt32("AdminId", user.IdQuanLy);
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
            session.Remove("AdminId");

            // Trả về một response cho client
            return Json(new { success = true });
        }

    }
}
