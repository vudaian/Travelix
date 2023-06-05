using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using travelix.Model.Entities;
using travelix.Service;


namespace travelix.Areas.User.Controllers
{
    public class TourListController : Controller
    {
        private readonly TravelixContext _context;
        public TourListController(TravelixContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public ActionResult GetTourDetails()
        {
            var tourDetails = (from tour in _context.Tours
                                join location in _context.Diadiems on tour.IdDiaDiem equals location.IdDiaDiem
                                select new
                                {
                                    tour.Anh,
                                    tour.Gia,
                                    tour.DiemDon,
                                    tour.IdTour,
                                    location.TenDiaDanh
                                }).ToList();

            return Json(tourDetails);
        }
    }
}
