using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using travelix.Model.Entities;
using travelix.Service;

namespace travelix.Areas.User.Controllers
{
    public class NewsListController : Controller
    {
        private readonly INewsService _service;
        public NewsListController(INewsService service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            return View();
        }
        public JsonResult List()
        {
            IEnumerable<Tintuc> tintucs = _service.GetAllNews();
            return Json(tintucs);
        }
    }
}
