using System;
using System.Collections.Generic;

#nullable disable

namespace travelix.Model.Entities
{
    public partial class Khachhang
    {
        public Khachhang()
        {
            Dattours = new HashSet<Dattour>();
        }

        public int IdKhachHang { get; set; }
        public string TenKhachHang { get; set; }
        public string SoDienThoai { get; set; }
        public DateTime? NgaySinh { get; set; }
        public string Email { get; set; }
        public string MatKhau { get; set; }

        public virtual ICollection<Dattour> Dattours { get; set; }
    }
}
