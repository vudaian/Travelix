using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace travelix.Model.Entities
{
    public partial class Taikhoanquanly
    {
        public int IdQuanLy { get; set; }
        public string TaiKhoan { get; set; }
        public string MatKhau { get; set; }

        public virtual Quanly IdQuanLyNavigation { get; set; }
    }
}
