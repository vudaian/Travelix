using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using travelix.Model.Entities;

namespace travelix.Areas.User.Controllers
{
    public class BookingTourController : Controller
    {
        private readonly TravelixContext _context;
        public BookingTourController(TravelixContext context)
        {
            _context = context;
        }
        public JsonResult GetMaxBookTourId()
        {
            var maxId = _context.Dattours.Max(u => u.IdDatTour);
            var bookTourIdMax = _context.Dattours.FirstOrDefault(u => u.IdDatTour == maxId);
            return Json(bookTourIdMax);
        }
    }
}
