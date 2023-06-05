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
    public class NewsController : Controller
    {
        private readonly INewsService _service;
        public NewsController(INewsService service)
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
            IEnumerable<Tintuc> tintucs = _service.GetAllNews();
            return Json(tintucs);
        }

        [HttpPost]
        public JsonResult Add([FromBody] Tintuc tintuc)
        {
            _service.InsertNews(tintuc);
            return Json(tintuc);
        }
        [HttpPost]
        public JsonResult Update([FromBody] Tintuc tintuc)
        {
            _service.UpdateNews(tintuc);
            return Json(tintuc);
        }
        public JsonResult GetById(int id)
        {
            Tintuc tintuc = _service.GetNews(id);
            return Json(tintuc);
        }

        public JsonResult Delete(int id)
        {
            _service.DeleteNews(id);
            return Json(id);
        }
    }
}
