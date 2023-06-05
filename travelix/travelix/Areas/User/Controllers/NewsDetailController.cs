using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using travelix.Model.Entities;
using travelix.Service;

namespace travelix.Areas.User.Controllers
{
    public class NewsDetailController : Controller
    {
        private readonly INewsService _service;
        public NewsDetailController(INewsService service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            if (HttpContext.Session.GetInt32("UserId") == null)
            {
                return Redirect("/User/SignInSignUp/Index");
            }
            return View();
        }

        public JsonResult GetNewsId(int id)
        {
            Tintuc tintuc = _service.GetNews(id);
            return Json(tintuc);
        }
    }
}
