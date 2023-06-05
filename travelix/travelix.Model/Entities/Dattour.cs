using System;
using System.Collections.Generic;

#nullable disable

namespace travelix.Model.Entities
{
    public partial class Dattour
    {
        public Dattour()
        {
            Thanhtoans = new HashSet<Thanhtoan>();
        }

        public int IdDatTour { get; set; }
        public int IdTour { get; set; }
        public int IdKhachHang { get; set; }
        public int? SoNguoi { get; set; }
        public int? TongTien { get; set; }
        public bool TrangThaiDatTour { get; set; }

        public virtual Khachhang IdKhachHangNavigation { get; set; }
        public virtual Tour IdTourNavigation { get; set; }
        public virtual ICollection<Thanhtoan> Thanhtoans { get; set; }
    }
}
