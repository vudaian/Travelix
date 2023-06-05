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
    public class TourController : Controller
    {
        private readonly ITourService _service;
        public TourController(ITourService service)
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
            IEnumerable<Tour> tours = _service.GetAllTour();
            return Json(tours);
        }

        [HttpPost]
        public JsonResult Add([FromBody] Tour tour)
        {
            _service.InsertTour(tour);
            return Json(tour);
        }
        [HttpPost]
        public JsonResult Update([FromBody] Tour tour)
        {
            _service.UpdateTour(tour);
            return Json(tour);
        }
        public JsonResult GetById(int id)
        {
            Tour tour = _service.GetTour(id);
            return Json(tour);
        }

        public JsonResult Delete(int id)
        {
            _service.DeleteTour(id);
            return Json(id);
        }
    }
}
