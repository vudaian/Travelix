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
    public class HomePageController : Controller
    {
        private readonly ITourService _service;
        public HomePageController(ITourService service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            return View();
        }
        public JsonResult ListTour()
        {
            IEnumerable<Tour> tours = _service.GetAllTour();
            return Json(tours);
        }
    }
}
