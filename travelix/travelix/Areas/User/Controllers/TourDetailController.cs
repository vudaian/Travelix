using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using travelix.Model.Entities;
using travelix.Service;

namespace travelix.Areas.User.Controllers
{
    public class TourDetailController : Controller
    {
        private readonly ITourService _service;
        public TourDetailController(ITourService service)
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

        public JsonResult GetTourId(int id)
        {
            Tour tour = _service.GetTour(id);
            return Json(tour);
        }

    }
}
