using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using travelix.Model.Entities;

namespace travelix.Areas.Administrator.Controllers
{
    public class SearchController : Controller
    {
        private readonly TravelixContext _context;

        public SearchController(TravelixContext context)
        {
            _context = context;
        }

        public ActionResult SearchCustomer(string searchTerm)
        {
            string lowercaseSearchTerm = searchTerm.ToLower();

            // Thực hiện tìm kiếm khách hàng dựa trên tên
            var customers = _context.Khachhangs
                .Where(c => c.TenKhachHang.ToLower().Contains(lowercaseSearchTerm))
                .ToList();

            var results = customers.Select(c => new
            {
                IdKhachHang = c.IdKhachHang,
                TenKhachHang = c.TenKhachHang,
                SoDienThoai = c.SoDienThoai,
                NgaySinh = c.NgaySinh
            });

            return Json(results);
        }
        public ActionResult SearchAddress(string searchTerm)
        {
            string lowercaseSearchTerm = searchTerm.ToLower();

            // Thực hiện tìm kiếm địa danh dựa trên tên địa danh
            var customers = _context.Diadiems
                .Where(c => c.TenDiaDanh.ToLower().Contains(lowercaseSearchTerm))
                .ToList();

            var results = customers.Select(c => new
            {
                IdDiaDiem = c.IdDiaDiem,
                DiaChi = c.DiaChi,
                TenDiaDanh = c.TenDiaDanh
            });

            return Json(results);
        }

        public ActionResult SearchNews(string searchTerm)
        {
            string lowercaseSearchTerm = searchTerm.ToLower();

            // Thực hiện tìm kiếm địa danh dựa trên tên địa danh
            var customers = _context.Tintucs
                .Where(c => c.TieuDe.ToLower().Contains(lowercaseSearchTerm))
                .ToList();

            var results = customers.Select(c => new
            {
                IdTinTuc = c.IdTinTuc,
                TieuDe = c.TieuDe,
                NoiDung = c.NoiDung,
                Anh = c.Anh
            });

            return Json(results);
        }

        public ActionResult SearchTour(string searchTerm)
        {
            string lowercaseSearchTerm = searchTerm.ToLower();

            // Thực hiện tìm kiếm địa danh dựa trên tên địa danh
            var customers = _context.Tours
                .Where(c => c.IdTour.ToString().Contains(lowercaseSearchTerm))
                .ToList();

            var results = customers.Select(c => new
            {
                IdTour = c.IdTour,
                IdDiaDiem = c.IdDiaDiem,
                Gia = c.Gia,
                DiemDon = c.DiemDon,
                Anh = c.Anh
            });

            return Json(results);
        }
    }
}
