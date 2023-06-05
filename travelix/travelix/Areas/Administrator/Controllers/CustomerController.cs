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
    public class CustomerController : Controller
    {
        private readonly ICustomerService _service;
        public CustomerController(ICustomerService service)
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
        public JsonResult List()
        {
            IEnumerable<Khachhang> khachhangs = _service.GetAllCustomer();
            return Json(khachhangs);
        }

        [HttpPost]
        public JsonResult Add([FromBody] Khachhang khachhang)
        {
            _service.InsertCustomer(khachhang);
            return Json(khachhang);
        }
        [HttpPost]
        public JsonResult Update([FromBody] Khachhang khachhang)
        {
            _service.UpdateCustomer(khachhang);
            return Json(khachhang);
        }
        public JsonResult GetById(int id)
        {
            Khachhang khachhang = _service.GetCustomer(id);
            return Json(khachhang);
        }

        public JsonResult Delete(int id)
        {
            _service.DeleteCustomer(id);
            return Json(id);
        }

        public JsonResult GetUserInfo()
        {
            var session = HttpContext.Session;
            if (session.GetInt32("UserId") != null)
            {
                int userId = HttpContext.Session.GetInt32("UserId") ?? 0;
                Khachhang khachhang = _service.GetCustomer(userId);
                return Json(khachhang);
            }
            return Json(null);
        }
    }
}
