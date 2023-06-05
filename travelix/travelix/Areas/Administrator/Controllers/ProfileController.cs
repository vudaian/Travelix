using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using travelix.Model.Entities;
using travelix.Service;

namespace travelix.Areas.Administrator.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IAdminService _service;
        public ProfileController(IAdminService service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            var session = HttpContext.Session;
            if (session.GetInt32("AdminId") == null)
            {
                return Redirect("/Administrator/SignIn/Index");
            }
            else
            {
                return View();
            }
        }

        public JsonResult GetQuanLyInfo()
        {
            int quanLyId = HttpContext.Session.GetInt32("AdminId") ?? 0;
            Quanly quanlys = _service.GetAdmin(quanLyId);
            return Json(quanlys);
        }
        [HttpPost]
        public JsonResult Update([FromBody] Quanly quanly)
        {
            _service.UpdateAdmin(quanly);
            return Json(quanly);
        }
        public JsonResult GetById(int id)
        {
            Quanly quanly = _service.GetAdmin(id);
            return Json(quanly);
        }
    }
}
