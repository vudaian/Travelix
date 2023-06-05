using System;
using System.Collections.Generic;

#nullable disable

namespace travelix.Model.Entities
{
    public partial class Thanhtoan
    {
        public int IdThanhToan { get; set; }
        public int IdDatTour { get; set; }
        public string HinhThuc { get; set; }
        public bool? TrangThaiThanhToan { get; set; }

        public virtual Dattour IdDatTourNavigation { get; set; }
    }
}
