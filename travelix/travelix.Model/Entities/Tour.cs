using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace travelix.Model.Entities
{
    public partial class Tour
    {
        public Tour()
        {
            Dattours = new HashSet<Dattour>();
        }

        public int IdTour { get; set; }
        public int IdDiaDiem { get; set; }
        public int? Gia { get; set; }
        public string DiemDon { get; set; }
        public string Anh { get; set; }
        public string HuongDanVien { get; set; }
        public string PhuongTien { get; set; }
        public string GhiChu { get; set; }

        public virtual Diadiem IdDiaDiemNavigation { get; set; }
        public virtual ICollection<Dattour> Dattours { get; set; }
    }
}
