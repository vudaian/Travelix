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
    public class BookTourController : Controller
    {
        private readonly IBookTourService _service;
        public BookTourController(IBookTourService service)
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
            IEnumerable<Dattour> dattours = _service.GetAllBookTour();
            return Json(dattours);
        }

        [HttpPost]
        public JsonResult Add([FromBody] Dattour dattour)
        {
            _service.InsertBookTour(dattour);
            return Json(dattour);
        }
        [HttpPost]
        public JsonResult Update([FromBody] Dattour dattour)
        {
            _service.UpdateBookTour(dattour);
            return Json(dattour);
        }
        public JsonResult GetById(int id)
        {
            Dattour diadiem = _service.GetBookTour(id);
            return Json(diadiem);
        }

        public JsonResult Delete(int id)
        {
            _service.DeleteBookTour(id);
            return Json(id);
        }
    }
}
