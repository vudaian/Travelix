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
    public class AddressController : Controller
    {
        private readonly IAddressService _service;
        public AddressController(IAddressService service)
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
            IEnumerable<Diadiem> diadiems = _service.GetAllAddress();
            return Json(diadiems);
        }

        [HttpPost]
        public JsonResult Add([FromBody] Diadiem diadiem)
        {
            _service.InsertAddress(diadiem);
            return Json(diadiem);
        }
        [HttpPost]
        public JsonResult Update([FromBody] Diadiem diadiem)
        {
            _service.UpdateAddress(diadiem);
            return Json(diadiem);
        }
        public JsonResult GetById(int id)
        {
            Diadiem diadiem = _service.GetAddress(id);
            return Json(diadiem);
        }

        public JsonResult Delete(int id)
        {
            _service.DeleteAddress(id);
            return Json(id);
        }
    }
}
